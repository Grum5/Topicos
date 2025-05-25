
use actix_web::{App, HttpServer};

// Importando mis modulos
mod dominio;
mod infraestructura;

use crate::infraestructura::db::sql_controller::DbController;

// Path de la base de datos (No es apto para producción colocar aqui esta informacion, esta hecho
// con fines practicos de desarollo y testeo).
pub const DB_PATH: &str = "sqlite://agenda.db";

#[actix_web::main]
async fn main() -> std::io::Result<()> {

    // Creando el controlador de la DB
    let _db_controller = DbController::new(DB_PATH).await;


    // Iniciando el servidor HTTP
    HttpServer::new(|| App::new()
        // Configurando los servicios del servidor (Las rutas)
        .configure(infraestructura::http::config)
    )
    .bind(("0.0.0.0", 8080))?  // IP y puerto del servidor
    .run()
    .await
}
