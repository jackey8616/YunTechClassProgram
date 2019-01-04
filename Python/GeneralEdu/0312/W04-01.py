num = int(input("Number: "))

if num == 0:
    print("零")
elif num % 2 == 0:
    print("負偶數" if num < 0 else "正偶數")
else:
    print("負奇數" if num < 0 else "正奇數")
    