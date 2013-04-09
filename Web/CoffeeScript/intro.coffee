# CoffeeScript

#Assignment
number = 42
opposite = true

#Condition
number = -42 if opposite

#Functions
square = (x) -> x * x

#Arrays
list = [1,2,3,4,5]

#Objects
math = 
    root: Math.sqrt
    square: sqaure
    cube: (x) -> x * square x

#Splats
race = (winner, runners...) ->
    print winner, runners

#Existence
alert "I knew it!" if elvis?

#Array Comprehension
cubes = (math.cube num for num in list)