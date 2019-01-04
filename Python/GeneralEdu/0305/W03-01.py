import sys
import decimal


sum = 0
for i in range(1, 4):
    print('{0}\'s number is: {1}'.format(i, sys.argv[i]))
    sum += decimal.Decimal(sys.argv[i])
print('Sum is: {0}'.format(sum))