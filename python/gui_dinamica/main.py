import tkinter as tk                    # Importando tkinter como tk
from myModule.dinamic_control import (  # Importando las clases necesarias de myModule
    Dinamic_Control
)

class App:
    ''' Clase App, ejecuta las ventanas '''
    def __init__(self):
        ''' Contructor '''

        # Inicializando la ventana principal
        self.main_window = tk.Tk()                  # Instancia de la ventana raiz (root/master)
        self.main_window.title('Gui dinamica')      # Definiendo el titulo de la ventana
        self.main_window.geometry('600x400')        # Definiendo tamaño de la ventana
        self.main_window.resizable(False, False)    # Definiendo propiedades de la ventana para evitar que cambie el tamaño
        
        # Crear instancia que administre controles dinamicos desde myModule
        self.control_manager = Dinamic_Control(self.main_window)

# -------------------------------------------------------------------

if __name__ == '__main__':

    app = App()                 # Creando objeto de la clase App
    app.main_window.mainloop()  # Metodo de loop de tkinter
