from Clock import Clock

def main():
    # Creating an instance of the Clock class
    my_clock = Clock()

    # Prompting the user to enter the number of ticks
    n = int(input("Enter the number of ticks: "))

    
    for i in range(n + 1): # for i = 0, i <=n, i++
        my_clock.ticks() 
        print(my_clock.display_time())  # Displaying the current time

    # Resetting the clock to 00:00:00
    my_clock.reset()
    print("\nReset clock:")
    print(my_clock.display_time())  # Displaying the time after resetting the clock

# Calling the main function 
if __name__ == "__main__":
    main()