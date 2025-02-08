import tkinter as tk
from tkinter import messagebox


class Dinamic_Control:
    ''' Clase encargada de controlar el ingreso de controles '''

    def __init__(self, window):

        # Instacia window
        self.window = window

        # Main Button | Genera mas controles con Entry y Buttons
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

        # Evaluar se llego al limite de controles preestablecido
        if self.index_ctrl_dict >= 5: return

        # Incrementar el indice
        self.index_ctrl_dict += 1

        # Generar el Frame contenedor de los controles
        container = tk.Frame(self.window)
        container.pack(pady=5)

        # Agregar la referencia y el indice al diccionario
        self.ctrl_dict[chr(self.index_ctrl_dict)] = container

        # Crear variable para contener una tupla y evaluar las entradas
        evaluation = (
            self.window.register(self.eval_entry),  # Se registran
            '%S',
            self.index_ctrl_dict
        )

        # Generar el Entry en el contenedor
        entry = tk.Entry(
            container,
            validate='key',      # Validar el tipo de accion, en este caso un Key
            validatecommand=evaluation
        )
        entry.pack(side=tk.LEFT, padx=5)

        # Generar el Button en el contenedor
        button = tk.Button(
                container,
                text=f"Boton {self.index_ctrl_dict}",
                command=lambda index=self.index_ctrl_dict: self.show_message(index)
        )
        button.pack(side=tk.LEFT)


# -------------------------------------------------------------------

    def show_message(self, index):
        messagebox.showinfo('Boton presionado', f'Presionaste el boton {index}')

# -------------------------------------------------------------------

    def eval_entry(self, char, index):
        if int(index) % 2 == 0:      # Si es par se evalua si ocupa numeros
            return self.is_number(char)
        else:
            return self.is_text(char)
    

# -------------------------------------------------------------------

    def is_text(self, data):
        return data.isalpha()

# -------------------------------------------------------------------

    def is_number(self, data):
        return data.isdigit()

