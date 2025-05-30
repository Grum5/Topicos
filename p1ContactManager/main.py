import tkinter as tk
from myModules.contactAdder import ContactAdder


class App:

    def __init__(self):
        
        self.root = tk.Tk()
        self.root.geometry('400x600')
        self.root.wm_minsize(width=400, height=600)
        self.root.title('Gestor de contactor')

        self.formulary = ContactAdder(self.root)

if __name__ == '__main__':
    
    app = App()
    app.root.mainloop()
