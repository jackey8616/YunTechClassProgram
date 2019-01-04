age = int(input("Age: "))

if age < 1:
    print("不合理")
elif age <= 5:
    print("普通級")
elif age <= 11:
    print("保護級")
elif age <= 17:
    print("輔導級")
else:
    print("限制級")