use serde::{Serialize, Deserialize};
use sqlx::FromRow;

#[derive(Debug, Deserialize, Serialize, FromRow)]
pub struct Usuario {
    // Estructura para la base de datos

    pub id: Option<u32>,
    pub usuario: String,
    pub clave: String,
    pub email: String,
    pub activo: u8,
}

#[derive(Debug)]
pub enum AuthError {
    InvalidCredentials,
    InactiveUser,
    NotFound,
    DatabaseError,
}

#[derive(Debug, Deserialize)]
pub struct UserAuth {
    // Estructura para recibir el JSON de autenticación del usuario
    
    pub id: Option<u32>,
    pub usuario: Option<String>,
    pub clave: Option<String>
}

#[derive(Serialize)]
pub struct OkResponse {
    // Estructura para devolver un JSON con una respuesta
    
    pub mensaje: String,
    pub usuario: String,
    pub id: Option<u32>
}

#[derive(Serialize)]
pub struct ErrorResponse {
    // Estructura para devolver un JSON con una respuesta de Error
    
    pub error: String
}

