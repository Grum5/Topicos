import tkinter as tk
from tkinter import messagebox
from myModules.personalWidgets.card import Card


class ContactAdder:

    def __init__(self, root):
        ''' Constructor '''

        # Instancia de la ventana root
        self.root = root

        # Creando un diccionario para almacenar la lista de contactos
        self.contact_dict = {}
        
        # Crear un ID unico para los cards en el diccionario
        self.contact_id_counter = 1

        # Definir la cantidad maxima de contactos soportada en la lista
        self.max_contact = 5

        # Frame superior, dedicado a los Entry y Buttons
        self.top_form_frame = tk.Frame(
            self.root,
            bg='gray25'
        )
        self.top_form_frame.rowconfigure((0), weight=1)
        self.top_form_frame.columnconfigure((0,1), weight=1)
        self.top_form_frame.place(
            x=0,
            y=0,
            relwidth=1,
            relheight=0.3,
        )
        
        # Mandando llamar metodo para la creacion del top Frame
        self.create_top_form_frames()
        
        # Frame inferior, dedicado a almacenar los contactos agregados
        self.bottom_form_frame = tk.Frame(
            self.root,
            bg='gray25'
        )
        self.bottom_form_frame.place(
            x=0,
            rely=0.3,
            relwidth=1,
            relheight=0.7,
        )

        # Mandando llamar metodo para la creacion del Bottom Frame
        self.create_bottom_form_frame()

# -------------------------------------------------------------------

    def create_top_form_frames(self):
        ''' Metodo encargado de personalizar y mostrar los frames '''

        self.entry_lframe = tk.LabelFrame(
            self.top_form_frame,
            text='',
            background='gray25',
        )
        self.entry_lframe.rowconfigure((0,1,2,3,4,5), weight=1)
        self.entry_lframe.columnconfigure((0), weight=1)
        self.entry_lframe.grid(
            row=0,
            column=0,
            padx=1,
            pady=1,
            sticky='nsew'
        )

        self.create_entries()

        self.btn_frame = tk.Frame(
            self.top_form_frame,
            background='gray25'
        )
        self.btn_frame.rowconfigure((0,1), weight=1)
        self.btn_frame.columnconfigure((0), weight=1)
        self.btn_frame.grid(
            row=0,
            column=1,
            padx=1,
            pady=1,
            sticky='nsew'
        )

        self.create_btn()

# -------------------------------------------------------------------

    def create_bottom_form_frame(self):

        # Creando un LabelFrame para almacenar los cards de los contactos
        self.listbox_lframe = tk.LabelFrame(
            self.bottom_form_frame,
            text='Contact list',
            background='gray27',
            
        )
        self.listbox_lframe.place(
            relx=0.01,
            rely=0.01,
            relwidth=0.98,
            relheight=0.98
        )
        


# -------------------------------------------------------------------
        
    def create_entries(self):
        ''' Metodo encargado de crear y personalzar los Entries del formulario '''

        # Crear Label y Entry de Name
        self.name_label = tk.Label(
            self.entry_lframe,
            justify='left',
            text='Name: '
        )
        self.name_label.grid(
            row=0,
            column=0,
            pady=1,
            padx=15,
            sticky='w'
        )

        self.name_entry = tk.Entry(
            self.entry_lframe,
        )
        self.name_entry.grid(
            padx=10,
            row=1,
            column=0,
            sticky='ew'
        )


        # Crear Label y Entry de Number
        self.number_label = tk.Label(
            self.entry_lframe,
            justify='left',
            text='Number: '
        )
        self.number_label.grid(
            row=2,
            column=0,
            pady=1,
            padx=15,
            sticky='w'
        )
        self.number_entry = tk.Entry(
            self.entry_lframe,
        )
        self.number_entry.grid(
            padx=10,
            row=3,
            column=0,
            sticky='ew'
        )

        # Crear Label y Entry de Email
        self.email_label = tk.Label(
            self.entry_lframe,
            justify='left',
            text='Email: '
        )
        self.email_label.grid(
            row=4,
            column=0,
            pady=1,
            padx=15,
            sticky='w'
        )
        self.email_entry = tk.Entry(
            self.entry_lframe,
        )
        self.email_entry.grid(
            padx=10,
            row=5,
            column=0,
            sticky='ew'
        )

# -------------------------------------------------------------------

    def create_btn(self):
        ''' Metodo para crear los botones '''

        # Agregando el boton 'Add' para agregar al contacto
        self.add_btn = tk.Button(
            self.btn_frame,
            text='Add',
            command=self.add_contact
        )
        self.add_btn.grid(
            pady=10,
            padx=3,
            row=0,
            column=0,
            sticky='nsew'
        )

        # Agregando el boton clear, para eliminar al contacto
        self.clear_btn = tk.Button(
            self.btn_frame,
            text='Clear',
            command=self.clear_fields
        )
        self.clear_btn.grid(
            pady=10,
            padx=3,
            row=1,
            column=0,
            sticky='nsew'
        )

# -------------------------------------------------------------------

    def add_contact(self):
        ''' Metodo para agregar un contacto a la lista usando un widget personalizado llamado Card '''
        
        name = self.name_entry.get().strip()
        number = self.number_entry.get().strip()
        email = self.email_entry.get().strip()

        # Comprobar que los entry esten completos
        if not name or not number or not email:

            # Avisar que no se han rellenado los campos
            messagebox.showinfo('Ups!', 'No has llenado todos los campos')
            return

        # Comprobar que no se haya alcanzado la cantidad maxima de contactos preajustada
        if len(self.contact_dict) >= self.max_contact:

            # Avisar si ya se llego a la cantidad maxima de contactos
            messagebox.showinfo('Ups!', 'Se llego a la cantidad maxima de contactos')
            return

        # Creando el contacto
        contact = Card(
            container=self.listbox_lframe,
            name=name,
            number=number,
            email=email,
            callback=lambda id=chr(self.contact_id_counter) : self.delete_from_dict(id)
        )

        # Agregando el card al diccionario
        self.contact_dict[chr(self.contact_id_counter)] = contact
        
        # informar que se agrego un contacto
        messagebox.showinfo('Agregado', f'Se agrego a {contact.name}')

        # Incrementar el contador del id
        self.contact_id_counter += 1

# -------------------------------------------------------------------

    def clear_fields(self):
        ''' Metodo para vaciar los entry '''

        self.name_entry.delete(0, 'end')
        self.number_entry.delete(0, 'end')
        self.email_entry.delete(0, 'end')

# -------------------------------------------------------------------

    def delete_from_dict(self, id):
        ''' Metodo usado para eliminar la referencia del card del diccionario '''

        # Guardando la referencia especifica del Card desde el diccionario
        card = self.contact_dict[id]

        # Destruir el Card de el GUI
        card.destroy()

        # Mostrar status
        messagebox.showinfo('Elminado', f'Se elmino a {card.name}')

        # Eliminar la referencia del diccionario
        del self.contact_dict[id]

