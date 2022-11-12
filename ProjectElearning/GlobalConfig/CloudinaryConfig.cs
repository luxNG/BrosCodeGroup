using CloudinaryDotNet;

namespace ProjectElearning.GlobalConfig
{
    public class CloudinaryConfig
    {
         public Cloudinary configCloudinary()
        {
            Account account = new Account(
                 "drdgau7xv",
                 "872541741125815",
                 "2Mtz3j2mKQhABUwEwEEMUkHL_gg");
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            return cloudinary;
        }
    }
}
