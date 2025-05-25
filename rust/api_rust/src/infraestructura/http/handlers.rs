use actix_web::{post, web, HttpResponse};
use crate::dominio::models::{UserAuth, ErrorResponse, OkResponse};

// Definir el tipo de metodo HTTP (POST) y la ruta
#[post("/auth")]
async fn auth(data: Result<web::Json<UserAuth>, actix_web::Error>) -> HttpResponse {
    /*
    *   La función recibe como parametro un JSON con la misma estructura que UserAuth.
    *    - En caso de no recibir nada se maneja el error manualmente y se devuleve el error en
    *    formato JSON.
    *    - Si el JSON no cumple con los requisitos se devuelve un error en formato JSON.
    */ 

    // Usar match para verificar todos los posibles casos del Result<> enum
    match data {

        // Caso Ok (Se recibio un JSON y no un Error)
        Ok(data) => {

            // Verificar si los datos del JSON no son "None"
            if let (Some(user), Some(_password)) = (&data.usuario, &data.clave) {

                println!("Se recibio una solicitud /auth con datos:\n{:?}", data);

                // Crear la estructura de respuesta para el JSON
                let result: OkResponse = OkResponse {
                    mensaje: "Login exitoso".to_string(),
                    usuario: user.to_string(),
                    id: 123
                };

                // Mandar la respuesta con el JSON
                HttpResponse::Ok().json(result)
            }

            // Si el JSON esta incompleto entonces...
            else {

                // Crear la estructura de respuesta para el JSON
                let error: ErrorResponse = ErrorResponse {
                    error: "Usuario y contraseña requeridos".to_string()
                };

                // Mandar la respuesta con el JSON
                HttpResponse::BadRequest().json(error)
            }
        }

        // Si desde un inicio no se manda un JSON entonces...
        Err(_) => {

            
            // Crear la estructura de respuesta para el JSON
            let error: ErrorResponse = ErrorResponse {
                error: "Credenciales invalidas".to_string()
            };


            // Mandar la respuesta con el JSON
            HttpResponse::Unauthorized().json(error)
        }
    }
}
