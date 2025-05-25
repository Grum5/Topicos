
use actix_web::{App, HttpServer};
use sqlx::sqlite::SqlitePoolOptions;

// Importando mis modulos
mod dominio;
mod infraestructura;

// Path de la base de datos (No es apto para producción colocar aqui esta informacion, esta hecho
// con fines practicos de desarollo y testeo).
pub const DB_PATH: &str = "sqlite://agenda.db";

#[actix_web::main]
async fn main() -> std::io::Result<()> {

    // Creando el pool de la DB
    let pool = SqlitePoolOptions::new()
        .max_connections(5)
        .connect(DB_PATH)
        .await
        .expect("Error al conectarse a la base de datos");


    // Iniciando el servidor HTTP
    HttpServer::new(|| App::new()
        // Configurando los servicios del servidor (Las rutas)
        .configure(infraestructura::http::config)
    )
    .bind(("0.0.0.0", 8080))?  // IP y puerto del servidor
    .run()
    .await
}
