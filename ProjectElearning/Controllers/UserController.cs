using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using ProjectElearning.Data;
using ProjectElearning.DTO;
using ProjectElearning.GlobalConfig;
using ProjectElearning.IRepository;
using ProjectElearning.Models;
namespace ProjectElearning.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        public IUserRepository userRepository;
        public CloudinaryConfig cloudinaryConfig;
        public List<ImageStoreInformation> list;
        private ElearningContext elearningContext;
        public UserController(IUserRepository userRepository, ElearningContext elearningContext)
        {
            this.userRepository = userRepository;
            this.elearningContext = elearningContext;
            cloudinaryConfig = new CloudinaryConfig();
            list = new List<ImageStoreInformation>();
        }

        [HttpGet("getalluser")]
        public async Task<IActionResult> getAllUser()
        {
            var user = userRepository.getAllUserInformation();
            return Ok(user);
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult getUserById(int id)
        {
            User user = userRepository.getUserById(id);
            if(user == null)
            {
                return BadRequest("No information");
            }
            return Ok(user);
        }

        [HttpPut("/BlockAccount")]
        public IActionResult deleteUser(int id)
        {
            bool flag =   userRepository.deleteUserById(id);
            if(flag == false)
            {
                return BadRequest("Delete User failed");
            }
            return Ok("Delete user successful");
        }

        [HttpPut("/User/{id}/UpdateProfile")]
        public IActionResult updateUserInformation(int id, UserDTO userDTO)
        {
            User userFind = userRepository.getUserById(id);

            if(userFind == null)
            {
                return NotFound();
            }

            userFind.Fullname = userDTO.Fullname;
            userFind.Email = userDTO.Email;
            userFind.Password = userDTO.Password;
            userFind.Address = userDTO.Address;
            userFind.Phone = userDTO.Phone;
            userRepository.updateUserInformation(userFind); 
            return Ok("update success");
        }

      [HttpPost("UploadAvatar")]
      public List<ImageStoreInformation> uploadAvatarCloudinary(IFormFile uploadFile)
        {
           
            var cloudinary = cloudinaryConfig.configCloudinary();
            var uploadParams = new ImageUploadParams()
            {
               File = new FileDescription(uploadFile.FileName, uploadFile.OpenReadStream()),
               Folder = "ElearningAvatar",   
            };
           
         
            var uploadResult = cloudinary.Upload(uploadParams);
            ImageStoreInformation imageStoreInformation = new ImageStoreInformation()
            {
                imageUrl = uploadResult.SecureUrl.ToString(),
                publicId = uploadResult.PublicId,
                
            };
            list.Add(imageStoreInformation);
            return list;
        }

        [HttpPost]
        [Route("/CreateNewAccount")]
        public IActionResult createNewAccount(IFormFile? uploadAvatar, [FromForm] AccountDTO account)
        {
            string publicId = "", avatarUrl ="";
            if (uploadAvatar != null)
            {
              List<ImageStoreInformation>  listImage = uploadAvatarCloudinary(uploadAvatar);
              foreach(ImageStoreInformation getImageUrlAndPublicId in listImage)
                {
                    publicId = getImageUrlAndPublicId.publicId;
                    avatarUrl = getImageUrlAndPublicId.imageUrl;
                }
                listImage.Clear();
            }
            else
            {
                var cloudinary = cloudinaryConfig.configCloudinary();
                var uploadParam = new ImageUploadParams()
                {
                    File = new FileDescription("C:/Users/ADMIN/Desktop/ProjectElearning/ProjectElearning/Image/white.jpg"),
                    Folder = "ElearningAvatar",

                };
                var urlUploadDefaultImageResult = cloudinary.Upload(uploadParam);
                avatarUrl = urlUploadDefaultImageResult.SecureUrl.ToString();
                publicId = urlUploadDefaultImageResult.PublicId;
            }


            User user = new User
            {
                Id = account.id,
                Email = account.Email,
                Fullname = account.Fullname,
                Password = account.Password,
                Address = account.Address,
                Phone = account.Phone,
                Avatar = avatarUrl,
                PublicId = publicId,
                RoleId = 2,
                Status = true
            };

            userRepository.createUser(user);
            return Ok(user);

        }

        [HttpPost("/user/{id}/image/ChangeAvatar")]
        public IActionResult changeUserAvatar(int id, IFormFile formFile)
        {
            User user = userRepository.getUserById(id);

            var cloudinary = cloudinaryConfig.configCloudinary();
            var deletionParams = new DeletionParams(user.PublicId);
            var deletionResult = cloudinary.Destroy(deletionParams);
            
            List<ImageStoreInformation> list =  uploadAvatarCloudinary(formFile);
            foreach(ImageStoreInformation imageList in list)
            {
                user.Avatar = imageList.imageUrl;
                user.PublicId = imageList.publicId;
            }
            elearningContext.Users.Update(user);
            elearningContext.SaveChanges();
            return Ok(user);
        }

  

    }

}
