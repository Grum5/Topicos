
import tkinter as tk
from myModule.dinamic_control import Dinamic_Control

class App:
    ''' Clase App, ejecuta las ventanas '''
    def __init__(self):
        ''' Contructor '''

        # Inicializando la ventana principal
        self.main_window = tk.Tk()
        self.main_window.title('First app')
        self.main_window.geometry('600x400')
        self.main_window.resizable(False, False)
        
        # Crear instancia que administre controles
        self.control_manager = Dinamic_Control(self.main_window)

# -------------------------------------------------------------------

if __name__ == '__main__':

    app = App()
    app.main_window.mainloop()
