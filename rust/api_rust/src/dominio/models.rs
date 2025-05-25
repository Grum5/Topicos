use serde::{Serialize, Deserialize};

#[derive(Debug, Deserialize, Serialize)]
pub struct Usuario {
    // Estructura agregar al usuario a la base de datos

    pub id: Option<u32>,
    pub usuario: String,
    pub clave: String,
    pub email: String,
    pub activo: bool,
}

#[derive(Debug, Deserialize)]
pub struct UserAuth {
    // Estructura para recibir el JSON de autenticación del usuario
    
    pub usuario: Option<String>,
    pub clave: Option<String>
}

#[derive(Serialize)]
pub struct OkResponse {
    // Estructura para devolver un JSON con una respuesta
    
    pub mensaje: String,
    pub usuario: String,
    pub id: u32
}

#[derive(Serialize)]
pub struct ErrorResponse {
    // Estructura para devolver un JSON con una respuesta de Error
    
    pub error: String
}

