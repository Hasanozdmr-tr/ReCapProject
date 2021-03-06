using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //jwt json web token larının oluşturulabilmesi için credential yani anahtarımız (kullanıcı adı, parola)
        // verip imzalama nesnesine dönüştüreceğiz.
        //Hangi anahtar ve hangi doğrulama algoritmasının verileceğini gönderiyoruz.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
