from __future__ import print_function
from fractions import Fraction

n = int(raw_input("Input N: "))
var = []
for i in xrange(int(n)):
    temp = []
    for j in ' '.join(raw_input().strip().split(' ')).split():
        temp.append(Fraction(j))
    var.append(temp)

# Print matrix
def pprint():
    for i in xrange(int(n)):
        for j in xrange(int(n + 1)):
            print("%5s" % var[i][j], end='')
        print('\n', end='')
    print('\n', end='')

# Leading-1
for i in xrange(int(n)):
    factor = Fraction(var[i][i])
    for j in xrange(int(n + 1)):
        var[i][j] = Fraction(var[i][j] / factor)

flag = False
for i in xrange(int(n)):
    for j in xrange(int(n)):
        if i != j and var[i][i] != 0 and var[j][j] != 0:
            factor = Fraction(var[j][i] / var[i][i])
            for k in xrange(int(n + 1)):
                var[j][k] = Fraction(var[j][k] - (var[i][k] * factor))
            leading_factor = Fraction(var[j][j])
            if leading_factor == 0:
                if j == n:
                    flag = True
                    break
                else:
                    continue
            for k in xrange(int(n + 1)):
                var[j][k] = Fraction(var[j][k] / leading_factor)
    if flag == True:
        break

# Scan and print roots type Infinite Roots / No Root / Single Root. 
for i in xrange(int(n)):
    if(var[i][i] == 0):
        if(var[i][n] != 0):
            print('0')
        else:
            print('N')
        break;
    elif i == int(n) - 1:
        print('1')
# Print roots
for i in xrange(int(n)):
    print('X%d = %s' % ((i + 1), var[i][n]))
