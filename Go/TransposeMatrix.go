package main

import "fmt"

var (
    matrix [3][]int
)

func main() {
    fmt.Println("Input a 3x3 Matrix to Transpose.")
    for i:=0; i<3; i++ {
        var input [3]int
        fmt.Printf("Row %d -> ", i)
        fmt.Scanf("%d %d %d", &input[0], &input[1], &input[2])
        matrix[i] = append(matrix[i], []int{ input[0], input[1], input[2] }...)
    }

    fmt.Println("Originial Matrix:")
    for i := range(matrix) {
        fmt.Print("[ ")
        for j := range(matrix[i]) {
            fmt.Print(matrix[i][j], " ")
        }
        fmt.Println("]")
    }

    fmt.Println("Transpose Matrix:")
    for i:=2; i>=0; i-- {
        fmt.Print("[ ")
        for j:=0; j<3; j++ {
            fmt.Print(matrix[j][i], " ")
        }
        fmt.Println("]")
    }
}
