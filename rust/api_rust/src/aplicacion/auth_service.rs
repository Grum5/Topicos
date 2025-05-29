use crate::infraestructura::db::sql_controller::DbController;
use crate::dominio::models::Usuario;


pub struct AuthService {

    // Atributos
    db: DbController
}

impl AuthService {

    // Constructor
    pub fn new(db: DbController) -> Self {
        Self { db }
    }

    pub async fn login(&self, user: &str, password: &str) -> Result<bool, sqlx::Error> {
        /*
        *   Metodo que intenta validar un login.
        *       - Recibe el usuario y clave desde un handler
        *       - Retorna Ok(true) si todo es valido, Ok(false) si no, y Err si hay fallo en la DB.
        */

        // Llamar al metodo de infraestructura para buscar el usuario por nombre
        if let Some(_user) = self.db.get_user_by_name(user).await? {

            // Comparar si la clave ingresada coincide con el de la DB
            let valid_password = _user.clave == password;

            // Verifica si el usuario esta activo (1 = activo, 0 = inactivo)
            let is_active = _user.activo == 1;

            // Si ambas condiciones son verdaderas se genera un login exitoso
            if valid_password && is_active { 
                return Ok(true);
            }
        }

        // Si no se retorna un false
        Ok(false)
    }

    pub async fn register(&self, usuario: &Usuario) -> Result<(), sqlx::Error> {
        self.db.create_user(usuario).await
    }

}
