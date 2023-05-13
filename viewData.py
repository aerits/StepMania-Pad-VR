# program that turns position data into a graph
import matplotlib.pyplot as plt
import numpy as np
import re

# count lines
with open('output.txt') as f:
    line_count = 0
    for line in f:
        line_count += 1

# open file containing position matrix from main.cs
data = open("output.txt")

# init array of zeroes with each column containing m1 --> m12 from openvr
array = np.zeros([line_count,12])

# for a given string, return that string up until a space or } by recursively
# iterating through each character until a character is a space or }
def subsString(string):
    if(string[0] == " "):
        return ""
    elif(string[0]=="}"):
        return ""
    else:
        return string[0] + subsString(string[1:])

# recursively iterate through a string
# if it sees m1 --> m12, add that to the array
def formatData(d, array):
    if(len(d) == 0):
        return ""
    else:
        tmp = d[0:3]
        if(tmp == "M11"):
            array[0] = float(subsString(d[4:]))
        elif(tmp == "M12"):
            array[1] = float(subsString(d[4:]))
        elif(tmp == "M13"):
            array[2] = float(subsString(d[4:]))
        elif(tmp == "M14"):
            array[3] = float(subsString(d[4:]))
        elif(tmp == "M21"):
            array[4] = float(subsString(d[4:]))
        elif(tmp == "M22"):
            array[5] = float(subsString(d[4:]))
        elif(tmp == "M23"):
            array[6] = float(subsString(d[4:]))
        elif(tmp == "M24"):
            array[7] = float(subsString(d[4:]))
        elif(tmp == "M31"):
            array[8] = float(subsString(d[4:]))
        elif(tmp == "M32"):
            array[9] = float(subsString(d[4:]))
        elif(tmp == "M33"):
            array[10] = float(subsString(d[4:]))
        elif(tmp == "M34"):
            array[11] = float(subsString(d[4:]))
        return d[0] + formatData(d[1:], array)
# iterate through each line of the text file with
# position data to add all data to the array
for i in range(line_count):
    tmp = data.readline()
    formatData(tmp, array[i])

# rotate the array clockwise so that each column is a row
# m1 m2 m3         m1 m1 m1
# m1 m2 m3 ... ->  m2 m2 m2 ...
# m1 m2 m3         m3 m3 m3
array = np.fliplr(array)
array = np.rot90(array)
# plot each line with pyplot and label them with the
# valve variable names
for i in range(12):
    plt.plot(array[i], label=str(i+1))
# show line names
leg = plt.legend(loc='upper right')
plt.show()

data.close