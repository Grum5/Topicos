import tkinter as tk


class ScrollFrame(tk.Frame):

    def __init__(self, master, **kwargs):
        super().__init__(master, **kwargs)

        # Crear el Canvas y el Scrollbar
        self.canvas = tk.Canvas(self, highlightthickness=0, **kwargs)
        self.scrollbar = tk.Scrollbar(
            self,
            orient='vertical',
            command=self.canvas.yview
        )

        # Frame que contendra widgets dentro del canvas
        self.scrollable_frame = tk.Frame(self.canvas, **kwargs)

        # Config del canvas para que sea desplazable
        self.scrollable_frame.bind(
                '<Configure>',
                lambda e: self.canvas.configure(
                    scrollregion=self.canvas.bbox('all')
                )
        )

        # Creacion de una ventana en el Canvas para el frame desplazable
        self.canvas.create_window(
            (0, 0),
            window=self.scrollable_frame,
            anchor='nw'
        )
        self.canvas.configure(yscrollcommand=self.scrollbar.set)

        # Mostrar el Canvas y el scrollbar
        self.canvas.pack(side='left', fill='both', expand=True)
        self.scrollbar.pack(side='right', fill='y')

        # Ajustar el tamaño del Frame interno cuando cambie el tamaño del Canva
        self.canvas.bind('<Configure>', self.on_canvas_configure)

        self.canvas.bind_all('<MouseWheel>', self.on_mouse_wheel)

        self.scrollable_frame.bind('<MouseWheel>', self.on_mouse_wheel)

    def on_canvas_configure(self, event):
        self.canvas.itemconfig('all', width=event.width)

    def on_mouse_wheel(self, event):
        self.canvas.yview_scroll(int(-1 * (event.delta / 120)), 'units')
