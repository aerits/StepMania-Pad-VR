# program that turns position data into a graph
import matplotlib.pyplot as plt
import numpy as np
import re

with open('output.txt') as f:
    line_count = 0
    for line in f:
        line_count += 1

# open file containing position matrix from main.cs
data = open(r"C:\Users\steven\Documents\ddr with fbt\output.txt")

#array = np.empty(335)
array = np.zeros([line_count,12])


def subsString(string):
    if(string[0] == " "):
        return ""
    elif(string[0]=="}"):
        return ""
    else:
        return string[0] + subsString(string[1:])

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
    
def addToArray():
    tmp = data.readline()
    if(tmp == ""):
        return 0
    else:
        for i in range(12):
            formatData(tmp, array[i])
    return addToArray()

for i in range(line_count):
    tmp = data.readline()
    formatData(tmp, array[i])
    print(array)

# addToArray()
# print(array)

array = np.fliplr(array)
array = np.rot90(array)

for i in range(12):
    plt.plot(array[i], label=str(i+1))

# plt.plot(array[3], label=str(3))

leg = plt.legend(loc='upper right')
plt.show()

data.close