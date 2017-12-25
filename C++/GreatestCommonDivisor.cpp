#include <stdio.h>

int main(void) {

	int a = 0, b = 0, calA = 0, calB = 0;
	printf("Please input A and B:");
	scanf("%d %d", &a, &b);
	calA = a;
	calB = b;
	while(calA != 0 && calB != 0) {
		if(calA / calB != 0)
			calA = calA % calB;
		else
			calB = calB % calA;
	}
	printf("(%d, %d) = %d", a, b , calA == 0 ? calB : calA);

	return 0;
}
