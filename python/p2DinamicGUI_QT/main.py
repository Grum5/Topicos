import sys
from PySide6 import QtCore, QtWidgets, QtGui


class MyWidget(QtWidgets.QWidget):

    def __init__(self):
        super().__init__()

        self.layout = QtWidgets.QVBoxLayout(self)


if __name__ == '__main__':
    app = QtWidgets.QApplication([])

    widget = MyWidget()
    widget.resize(800, 800)
    widget.show()

    sys.exit(app.exec())
