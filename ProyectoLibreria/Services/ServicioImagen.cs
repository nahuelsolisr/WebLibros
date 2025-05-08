
using Firebase.Auth;
using Firebase.Storage;

namespace ProyectoLibreria.Services
{
    public class ServicioImagen : IServicioImagen
    {
        public async Task<string> SubirImagen(Stream archivo, string nombre)
        {
            string email = "";
            string clave = "";
            string ruta = "peliculasdemo.appspot.com";
            string api_key = "AIzaSyChhPnzaVrpRraIo1J05esK_mzo7gb4Ruk";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);
            var cencellation = new CancellationTokenSource();
            var task = new FirebaseStorage(
                ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true,
                })
                .Child("Fotos_Perfil")
                .Child(nombre)
                .PutAsync(archivo, cencellation.Token);
            var downloadURL = await task;
            return downloadURL;
        }
    }
}
