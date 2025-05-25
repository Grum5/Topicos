
use sqlx::{SqlitePool};
use crate::dominio::models::{Usuario, UserAuth};


// Creando una estructura SqliteController para manejarla como si fuera POO
pub struct DbController {

    // Atributos
    pool: SqlitePool,
}

// Implementando los metodos de la estructura
impl DbController {

    // Constructor
    pub fn new(pool: SqlitePool) -> Self {
        Self { pool }
    }

    // pub async fn create_user(&self, user: &UserAuth) -> Result<(), String> {

    // }

}

