package main

import (
    "fmt"
)

var(
    infix string
    stack string
    output string
)

func main() {
    fmt.Print("Enter a infix: ")
    fmt.Scanln(&infix)
    fmt.Printf("Infix is: %s\n", infix)

    for i := range infix {
        switch string(infix[i]) {
            case "(":
                stack += string(infix[i])
                break
            case "+", "-", "*", "/":
                for j:=len(stack) - 1; j>=0; j-- {
                    if priority(string(stack[j])) >= priority(string(infix[i])) {
                        output += string(stack[j])
                        stack = string(stack[:len(stack) - 1])
                    } else {
                        break
                    }
                }
                stack += string(infix[i])
                break
            case ")":
                for j:=len(stack) - 1; j>=0; j-- {
                    if string(stack[j]) == "(" {
                        break
                    } else {
                        output += string(stack[j])
                        stack = string(stack[:len(stack) - 1])
                    }
                }
                stack = string(stack[:len(stack) - 1])
                break
            default:
                output += string(infix[i])
                break
        }
    }
    for i:=len(stack) - 1; i>=0; i-- {
        output += string(stack[i])
    }
    fmt.Println(output)
}

func priority(op string) int {
    switch op {
        case "*", "/":
            return 2
        case "+", "-":
            return 1
        default:
            return 0
    }
}
