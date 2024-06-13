class Counter:
    
    def __init__(self, name):  #Constructor method for initializing a Counter object
        self.name = name  #Initialize the name of the counter
        self.count = 0  #Initialize the count of the counter to 0

    def increment(self):  #increment the count of the counter by 1
        self.count += 1

    def reset(self):  #reset the count of the counter to 0
        self.count = 0