import sys
import decimal
import math

arr = []

for i in range(1, len(sys.argv)):
    arr.append(math.sqrt(decimal.Decimal(sys.argv[i])))
print(arr)