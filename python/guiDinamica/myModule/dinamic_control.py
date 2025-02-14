import tkinter as tk
from tkinter import messagebox


class Dinamic_Control:
    ''' Clase encargada de controlar el ingreso de controles '''

    def __init__(self, window):
        ''' Constructor '''

        # Instacia window
        self.window = window
        
        # Definir la cantidad maxima de controles dinamicos (Yo escogi 5)
        self.max_dinamic_controls = 5

        # Main Button | Genera mas controles con en un Frame que tienen Entries y Buttons
        self.main_btn = tk.Button(
                self.window,
                text='Agregar nuevo control',
                command=self.add_new_control,
        )
        self.main_btn.pack()

        # Diccionario para almacenar los controles
        self.ctrl_dict = {}
        self.index_ctrl_dict = 0

# -------------------------------------------------------------------

    def add_new_control(self):
        ''' Funcion encargada de agregar un nuevo control con un Entry y un Button '''

        # Evaluar si se llego al limite de controles preestablecido y abandonar la funcion en caso de ser verdadero
        if self.index_ctrl_dict >= self.max_dinamic_controls: return

        # Incrementar el indice
        self.index_ctrl_dict += 1

        # Generar el Frame contenedor de los controles
        container = tk.Frame(self.window)
        container.pack(pady=5)

        # Agregar la referencia y el indice al diccionario
        self.ctrl_dict[chr(self.index_ctrl_dict)] = container

        # Crear variable para contener una tupla y evaluar las entradas
        evaluation = (
            self.window.register(self.eval_entry),  # register() Actua como un callback, se ocupa para que funcione la evaluacion de los entry
            '%S',                                   # Se evalua cada tecla ingresada
            self.index_ctrl_dict                    # Se manda el index del button
        )

        # Generar el Entry en el contenedor
        entry = tk.Entry(
            container,
            validate='key',                         # Validar el tipo de accion, en este caso un Key
            validatecommand=evaluation              
        )
        entry.pack(side=tk.LEFT, padx=5)

        # Generar el Button en el contenedor
        button = tk.Button(
                container,
                text=f"Boton {self.index_ctrl_dict}",

                # Se manda una funcion anonima a command para poder mandar el index del boton
                command=lambda index=self.index_ctrl_dict: self.show_message(index)

        )
        button.pack(side=tk.LEFT)


# -------------------------------------------------------------------

    def show_message(self, index):
        ''' Metodo encargado de abrir una ventana con un mensaje '''
        
        # Metodo de tkinter para abrir una caja con un mensaje
        messagebox.showinfo('Boton presionado', f'Presionaste el boton {index}')

# -------------------------------------------------------------------

    def eval_entry(self, char, index):
        ''' Metodo para evaluar los eventos de keypressed ''' 

        if int(index) % 2 == 0:     # Se evalua si el indice es par, si lo es se llama al metodo is_digit(char)
            return self.is_number(char)
        else:                       # Caso contrario se llama al metodo is_text(char)
            return self.is_text(char)
    

# -------------------------------------------------------------------

    def is_text(self, data):
        ''' Metodo que evalua si el dato es un caracter de texto '''

        return data.isalpha()

# -------------------------------------------------------------------

    def is_number(self, data):
        ''' Metodo que evalua si el dato es un digito '''

        return data.isdigit()

