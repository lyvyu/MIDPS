from Tkinter import *
from math import *
#import compiler

class Calculator(Frame):
	def insertNumbers(self, x):
		if self.needClr:
			self.clearAll()
			self.needClr = False

		if self.display.get() == "0":
			self.display.delete(0, END)

		self.display.insert(END, x)

	def clearAll(self):
		self.display.delete(0, END)
		# self.display.insert(0, 0)

	def undo(self):
		data = self.display.get()
		newVal = data[:-1]

		self.display.delete(0, END)

		self.display.insert(END, newVal)

	def invertNr(self):
		data = eval(self.display.get())

		self.clearAll()
		inverted = data * -1

		self.display.insert(0, inverted)

	def equal(self):
		#get data from input
		data = self.display.get()
		res = eval(data)
		# print res

		self.clearAll()
		# set clear if = was pressed
		self.needClr = True

		self.display.insert(END, res)

	def createButtons(self):
		#top buttons
  		Button(self, text = "AC", width = 3, command = self.clearAll).grid(row = 1, column = 1)
  		Button(self, text = "C", width = 3, command = self.undo).grid(row = 1, column = 2)
  		Button(self, text = "+/-", width = 3, command = self.invertNr).grid(row = 1, column = 3)

  		#numbers
  		Button(self, text = "1", width = 3, command = lambda : self.insertNumbers(1)).grid(row = 2, column = 1)
  		Button(self, text = "2", width = 3, command = lambda : self.insertNumbers(2)).grid(row = 2, column = 2)
  		Button(self, text = "3", width = 3, command = lambda : self.insertNumbers(3)).grid(row = 2, column = 3)
  		Button(self, text = "4", width = 3, command = lambda : self.insertNumbers(4)).grid(row = 3, column = 1)
  		Button(self, text = "5", width = 3, command = lambda : self.insertNumbers(5)).grid(row = 3, column = 2)
  		Button(self, text = "6", width = 3, command = lambda : self.insertNumbers(6)).grid(row = 3, column = 3)
  		Button(self, text = "7", width = 3, command = lambda : self.insertNumbers(7)).grid(row = 4, column = 1)
  		Button(self, text = "8", width = 3, command = lambda : self.insertNumbers(8)).grid(row = 4, column = 2)
  		Button(self, text = "9", width = 3, command = lambda : self.insertNumbers(9)).grid(row = 4, column = 3)
  		Button(self, text = "0", width = 9, command = lambda : self.insertNumbers(10)).grid(row = 5, column = 1, columnspan = 2)

  		#dot
  		Button(self, text = ".", width = 3, command = lambda : self.insertNumbers(".")).grid(row = 5, column = 3)

  		#right side operations
  		Button(self, text = "/", width = 3, command = lambda : self.insertNumbers("/")).grid(row = 1, column = 4)
  		Button(self, text = "x", width = 3, command = lambda : self.insertNumbers("*")).grid(row = 2, column = 4)
  		Button(self, text = "-", width = 3, command = lambda : self.insertNumbers("-")).grid(row = 3, column = 4)
  		Button(self, text = "+", width = 3, command = lambda : self.insertNumbers("+")).grid(row = 4, column = 4)
  		Button(self, text = "=", width = 3, command = self.equal).grid(row = 5, column = 4)

	def __init__(self, master):
		Frame.__init__(self, master)
		master.title("Calculator")
		# master.configure(bg = "black")

		self.pack(padx=20, pady=20)

		# global var
		self.needClr = False

		# setup display
		self.display = Entry(self, justify = RIGHT)
		self.display.grid(row = 0, column = 0, columnspan = 5)
		self.display.insert(0, 0)

		self.createButtons()


root = Tk();
app = Calculator(root);
root.mainloop();