import tkinter as tk


class Card(tk.LabelFrame):

    def __init__(self, container, name, number, email, callback):
        ''' Contructor '''

        # Llamando a los metodos y atributos de la clase padre
        super().__init__(container, background='gray28', padx=10, pady=5)

        # Inicializando los atributos de la clase
        self.name = name
        self.number = number
        self.email = email

        # Generando un Label para dar display de los datos
        self.text = tk.Label(
            self,
            text=f'Name: {self.name}\nNumber: {self.number}\nEmail: {self.email}',
            justify='left'
        )
        self.text.pack(fill='both', expand=True, side='left')
        
        # Creando el boton de Delete
        btn_delete = tk.Button(
            self,
            text='Delete',
            command=callback
        )
        btn_delete.pack(fill='both', expand=True,side='right')

        # Mostrar el objeto en la pantalla
        self.pack(fill='x', expand=True, side='top', anchor='n')

