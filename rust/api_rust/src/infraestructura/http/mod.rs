pub mod handlers;

use actix_web::web;

pub fn config(cfg: &mut web::ServiceConfig) {
    cfg.service(handlers::auth);
}
