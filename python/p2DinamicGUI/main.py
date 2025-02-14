import os
import tkinter as tk
from tkinter import filedialog
from PIL import Image, ImageTk
from myComponents import ScrollFrame


class ImagenPreviewer(tk.Frame):

    def __init__(self, master=None):
        ''' Contructor '''

        # Mandando llamar la clase padre
        super().__init__(master, bg='gray25')

        # Mostrando el Frame
        self.pack(fill='both', expand=True, padx=10, pady=10)

        # Definiendo el directorio de las imagenes
        self.images_dir = None

        # LabelFrame para contener las miniaturas
        self.pictures = MiniPicturesLabelFrame(self)

        # Boton para escoger el directorio
        self.main_btn = tk.Button(
            self,
            text='Buscar\ndirectorio',
            command=self.find_dir
        )
        self.main_btn.pack(before=self.pictures, side='top', expand=False, padx=40, pady=10)

    def find_dir(self):
        ''' Metodo encargado de encontrar un directorio para las imagenes '''

        # Buscando el directorio
        self.images_dir = filedialog.askdirectory()
        if self.images_dir:
            self.pictures.show_images(self.images_dir)


class MiniPicturesLabelFrame(tk.LabelFrame):

    def __init__(self, master=None):
        ''' Constructor '''

        # Mandando llamar la clase padre
        super().__init__(master, text='Pictures', bg='gray25')

        # Mostrando el LabelFrame
        self.pack(fill='both', expand=True, pady=5, padx=10)

        self.images_frame = ScrollFrame(self, bg='gray25')
        self.images_frame.pack(fill='both', expand=True, pady=5, padx=10)

    def show_images(self, dir):
        ''' Metodo que muestras las imagenes del directorio '''

        # Si hay imagenes en el LabelFrame, eliminarlas
        for elem in self.images_frame.scrollable_frame.winfo_children():
            elem.destroy()

        for filename in os.listdir(dir):
            if filename.lower().endswith(('.png', '.jpg', '.jpeg', '.gif')):
                picture_path = os.path.join(dir, filename)
                picture = Image.open(picture_path)
                picture.thumbnail((300, 300))

                photo = ImageTk.PhotoImage(picture)

                button = tk.Button(
                    self.images_frame.scrollable_frame,
                    image=photo,
                    command=lambda f=filename, p=picture_path: self.open_image(f, p)
                )
                button.image = photo
                button.pack(side='top', padx=5, pady=5)

    def open_image(self, name, path):
        image = Image.open(path)
        img_width, img_height = image.size

        screen_width = self.winfo_screenwidth()
        screen_height = self.winfo_screenheight()

        if img_width > screen_width or img_height > screen_height:
            scale = min(screen_width / img_width, screen_height / img_height) * 0.9
            new_width = int(img_width * scale)
            new_height = int(img_height * scale)
            image = image.resize((new_width, new_height), Image.LANCZOS)
        else:
            new_width, new_height = img_width, img_height

        second_win = tk.Toplevel(self)
        second_win.title(name)
        second_win.geometry(f'{new_width}x{new_height}')

        photo = ImageTk.PhotoImage(image)

        label = tk.Label(second_win, image=photo)
        label.image = photo
        label.pack(padx=10, pady=10)


if __name__ == '__main__':

    root = tk.Tk()
    root.geometry('500x500')
    root.wm_minsize(500, 500)
    root.title('Imagen previewer')

    previewer = ImagenPreviewer(master=root)

    root.mainloop()
