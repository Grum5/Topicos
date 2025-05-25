
use sqlx::{sqlite::SqlitePoolOptions, SqlitePool};
use std::path::Path;
use std::fs::File;
use crate::dominio::models::{Usuario, UserAuth};


// Creando una estructura SqliteController para manejarla como si fuera POO
pub struct DbController {

    // Atributos
    pub pool: SqlitePool,
}

// Implementando los metodos de la estructura
impl DbController {

    // Constructor
    pub async fn new(db_path: &str) -> Self {

        // Se extrae la ruta de la DB en un formato &str
        let file_path = db_path.strip_prefix("sqlite://").expect("Ruta invalida");
        // Se genera la ruta de la DB
        let path = Path::new(file_path);
        
        // Se verifica la existencia de la DB, si no existe se crea
        if !path.exists() {

            println!("¡¡¡ Base de datos no encontrada !!!. Creando {}" , file_path);
            File::create(path).expect("No se pudo crear el archivo de la DB");
        }

        // Si existe nomas se imprime en la CLI 
        else {
            println!("Base de datos ya existente en {}", file_path);
        }

        // Se crea el Pool de SQLite
        let pool = SqlitePoolOptions::new()
            .max_connections(5)
            .connect(db_path)
            .await
            .expect("No se pudo conectar al pool de SQLite");

        // Se le asigna al atributo de la clase el Pool creado
        DbController { pool }
    }


}

