from Counter import Counter #importing the Counter class from the Counter module

class Clock:
    #self. is used to refer to the Clock's instances
    def __init__(self): #constructor
        self.hour = Counter("Hours")
        self.minute = Counter("Minutes")
        self.second = Counter("Seconds")

    def ticks(self):
        self.second.increment()
        
        if (self.second.count == 60):
            self.minute.increment()
            self.second.reset()
            
        if (self.minute.count == 60):
            self.hour.increment()
            self.minute.reset()
            
        if (self.hour.count == 24):
            self.hour.reset()

    def reset(self): #reset the value of hour, minute and second
        self.hour.reset()
        self.minute.reset()
        self.second.reset()

       
    def display_time(self):  #display the current time in HH:MM:SS format
        return "{:02d}:{:02d}:{:02d}".format(self.hour.count, self.minute.count, self.second.count)
