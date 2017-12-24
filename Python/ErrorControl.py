#Python3
import random

matrixG = []
matrixH = []
msgU = []
transMsg = []
errorTransMsg = []
print("Input Matrix with 7x4, each column should seperate with \"ONE SINGLE\" space")
for each in range(4):
    row = input("Row: " + str(each) + " -> ").strip().split(" ")
    matrixG.append([int(row[0]), int(row[1]), int(row[2]), int(row[3]), int(row[4]), int(row[5]), int(row[6])])
print("MatrixG: ")
for each in matrixG:
    print(each)
print("MatrixH: ")

matrixH.append([1, 0, 0, matrixG[0][0], matrixG[1][0], matrixG[2][0], matrixG[3][0]])
matrixH.append([0, 1, 0, matrixG[0][1], matrixG[1][1], matrixG[2][1], matrixG[3][1]])
matrixH.append([0, 0, 1, matrixG[0][2], matrixG[1][2], matrixG[2][2], matrixG[3][2]])
for each in matrixH:
    print(each)

print("MessageU: ")
for each in range(4):
    msgU.append(random.randint(0, 1))
print(msgU)

print("Transmission: ")
for i in range(7):
    each = int(i)
    transMsg.append((msgU[0] * matrixG[0][each] + msgU[1] * matrixG[1][each] + msgU[2] * matrixG[2][each] + msgU[3] * matrixG[3][each]) % 2)
print(transMsg)

errorTransMsg = transMsg
errorPosition = random.randint(0, 6)
errorTransMsg[errorPosition] = int(not bool(errorTransMsg[errorPosition]))
print("Error Position: " + str(errorPosition) + "\nMessage: " + str(errorTransMsg))

matrixS = []
for each in range(3):
    sum = 0
    for every in range(7):
        sum += errorTransMsg[every] * matrixH[each][every]
    matrixS.append(sum % 2)
print("Syndrome: ")
print(matrixS)

for each in range(7):
    flag = True
    for every in range(3):
        if matrixH[every][each] != matrixS[every]:
            flag = False
            break
    if flag:
        print("Error bit detected at position " + str(each))
        break
