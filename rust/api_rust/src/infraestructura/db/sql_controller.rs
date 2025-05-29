
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

    pub async fn init_db(&self) -> Result<(), sqlx::Error> {
        sqlx::query(
            r#"
            CREATE TABLE IF NOT EXISTS usuarios (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                usuario TEXT NOT NULL,
                clave TEXT NOT NULL,
                email TEXT NOT NULL,
                activo INTERGER DEFAULT 1 NOT NULL
            );
            "#
        ).execute(&self.pool).await?;

        println!("Tabla 'usuarios' verificada/creada.");
        Ok(())
    }
    
    pub async fn get_user_by_name(&self, name: &str) -> Result<Option<Usuario>, sqlx::Error> {

        let result = sqlx::query_as::<_, Usuario>(
            "SELECT * FROM usuarios WHERE usuario = ?"
        )
        .bind(name)
        .fetch_optional(&self.pool)
        .await?;

        Ok(result)
    }

    pub async fn get_user_by_email(&self, email: &str) -> Result<Option<Usuario>, sqlx::Error> {

        let result = sqlx::query_as::<_, Usuario>(
            "SELECT * FROM usuarios WHERE email = ?"
        )
        .bind(email)
        .fetch_optional(&self.pool)
        .await?;

        Ok(result)
    }

    pub async fn create_user(&self, usuario: &Usuario) -> Result<(), sqlx::Error> {
        sqlx::query(
            r#"
            INSERT INTO usuarios (usuario, clave, email, activo)
            VALUES (?, ?, ?, ?)
            "#
        )
        .bind(&usuario.usuario)
        .bind(&usuario.clave)
        .bind(&usuario.email)
        .bind(usuario.activo as i32)
        .execute(&self.pool)
        .await?;

        Ok(())
    }
}

