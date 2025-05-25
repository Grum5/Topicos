use sqlx::{sqlite, Executor, SqlitePool};
use bcrypt::{hash, DEFAULT_COST};
use serde::{Deserialize, Serialize};

#[derive(Debug, Serialize, Deserialize)]
struct User {
    username: String,
    email: String,
    password: String
}


#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>> {

    let opt: sqlite::SqliteConnectOptions = sqlite::SqliteConnectOptions::new()
        .filename("test.db")
        .create_if_missing(true);

    let connection: SqlitePool = SqlitePool::connect_with(opt)
        .await?;

    connection.execute("
        CREATE TABLE IF NOT EXISTS users (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            username TEXT NOT NULL,
            email TEXT NOT NULL UNIQUE,
            password TEXT NOT NULL
        );
    ").await?;

    // Simulación: valores del usuario
    let username = "javi";
    let email = "javi@example.com";
    let raw_password = "supersecreta";

    // Encriptar password con bcrypt
    let hashed_password = hash(raw_password, DEFAULT_COST)?;

    // Insertar usuario
    sqlx::query("INSERT INTO users (username, email, password) VALUES (?1, ?2, ?3)")
        .bind(username)
        .bind(email)
        .bind(&hashed_password)
        .execute(&connection)
        .await?;
    
    Ok(())
}
