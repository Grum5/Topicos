use actix_web::{post, web, HttpResponse, web::Json};
use crate::aplicacion::auth_service::AuthService;
use crate::dominio::models::{AuthError, ErrorResponse, OkResponse, UserAuth, Usuario};

// Definir el tipo de metodo HTTP (POST) y la ruta
#[post("/auth")]
async fn auth(
    data: Result<Json<UserAuth>, actix_web::Error>, 
    servicio: web::Data<AuthService> ) -> HttpResponse {
    /*
    *   Funcion de metodo POST
    *       - Recibe un JSON con dos parametros (usuario, clave)
    *       - Recibe un servicio de actix_web, de la capa de aplicación
    *       - Valida cada caso posible en caso de recibir o no recibir un JSON
    */

    // Se utiliza match para verificar que se recibio correctamente el JSON
    match data {

        // Si se recibio el JSON correctamente
        Ok(data) => {

            // Verifivar si los campos 'usuario' y 'clave' estan presentes en el JSON
            if let (Some(usuario), Some(clave)) = (&data.usuario, &data.clave) {

                // Llamar al metodo login del servicio de aplicacion con los datos recibidos
                match servicio.login(usuario, clave).await {

                    // Si el login fue exitoso
                    Ok(user_auth) => {
                        
                        // Devuelve una respuesta HTTP 200 con un JSON indicando exito
                        HttpResponse::Ok().json(OkResponse {
                            mensaje: "Login exitoso".to_string(),
                            usuario: usuario.clone(),
                            id: user_auth.id, // podrías extender para devolver el id real
                            })
                    }

                    Err(err) => {
                        let mensaje = match err {
                            AuthError::InvalidCredentials => "Credenciales inválidas",
                            AuthError::InactiveUser => "Usuario inactivo",
                            AuthError::NotFound => "Usuario no encontrado",
                            AuthError::DatabaseError => "Error interno del servidor",
                        };

                        let mut codigo = match err {
                            AuthError::InvalidCredentials | AuthError::InactiveUser | AuthError::NotFound => HttpResponse::Unauthorized(),
                            AuthError::DatabaseError => HttpResponse::InternalServerError(),
                        };

                        codigo.json(ErrorResponse {
                            error: mensaje.to_string(),
                        })
                    }
                }
            }
            else {
                // Si el JSON esta bien formado pero faltan usuario o clave
                HttpResponse::BadRequest().json(ErrorResponse {
                    error: "Usuario y clave requeridos".to_string(),
                })
            }
        }

        // Si no se pudo serializar el JSON (se introducio un formato incorreto)
        Err(_) => HttpResponse::BadRequest().json(ErrorResponse {
            error: "Formato de entrada inválido".to_string(),
        }),
    }
}

#[post("/register")]
async fn register(
    data: Result<web::Json<Usuario>, actix_web::Error>,
    servicio: web::Data<AuthService>,
) -> HttpResponse {

    match data {

        Ok(usuario) => {

            match servicio.register(&usuario).await {

                Ok(_) => HttpResponse::Ok().json(OkResponse {
                    mensaje: "Usuario registrado exitosamente".to_string(),
                    usuario: usuario.usuario.clone(),
                    id: usuario.id,
                }),

                Err(e) => HttpResponse::InternalServerError().json(ErrorResponse {
                    error: format!("Error registrando usuario: {}", e),
                }),
            }
        }

        Err(_) => HttpResponse::BadRequest().json(ErrorResponse {
            error: "Datos inválidos".to_string(),
        }),
    }
}
