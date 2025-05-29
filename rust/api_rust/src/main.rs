
use actix_web::{web, App, HttpServer};
use aplicacion::auth_service::AuthService;

// Importando mis modulos
mod dominio;
mod infraestructura;
mod aplicacion;

use crate::infraestructura::db::sql_controller::DbController;

// Path de la base de datos (No es apto para producción colocar aqui esta informacion, esta hecho
// con fines practicos de desarollo y testeo).
pub const DB_PATH: &str = "sqlite://agenda.db";

#[actix_web::main]
async fn main() -> std::io::Result<()> {

    // Creando el controlador de la DB
    let _db_controller = DbController::new(DB_PATH).await;
    
    // Creando la tabla de la DB si se necesita
    _db_controller.init_db().await.expect("Error creando tablas");

    let auth_service = web::Data::new(AuthService::new(_db_controller));

    // Iniciando el servidor HTTP
    HttpServer::new(move || App::new()
        // Configurando los servicios del servidor (Las rutas)
        .app_data(auth_service.clone())
        .configure(infraestructura::http::config)
    )
    .bind(("127.0.0.1", 8080))?  // IP y puerto del servidor
    .run()
    .await
}
