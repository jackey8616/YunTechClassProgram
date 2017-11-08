#include <stdio.h>
#include <stdlib.h>

struct polynomial {
	int coef;
	int exp;
	struct polynomial *next;
};

void addition(struct polynomial *funA, struct polynomial *funB, struct polynomial *result) {
	struct polynomial *tempP = funA, *tempQ = funB;
	struct polynomial *ptr = (struct polynomial *)malloc(sizeof(struct polynomial));
	
	printf("A: 0x%.8x,\tB: 0x%.8x,\tC: 0x%.8x\n", tempP, tempQ, result);
	
	if (tempQ == (struct polynomial *)NULL || tempP->exp > tempQ->exp) {
		result->coef = tempP->coef;
		result->exp = tempP->exp;
		tempP = tempP->next;
	} else if(tempP == (struct polynomial *)NULL || tempQ->exp > tempP->exp) {
		result->coef = tempQ->coef;
		result->exp = tempQ->exp;
		tempQ = tempQ->next;
	} else {
		result->coef = tempP->coef + tempQ->coef;
        result->exp = tempP->exp;
        tempP = tempP->next;
        tempQ = tempQ->next;
	} 
	result->next = ptr;
	
	if(tempP == (struct polynomial *)NULL && tempQ == (struct polynomial *)NULL) { 
		result->next = (struct polynomial *)NULL;
		return;
	 } else {
		return addition(tempP, tempQ, ptr);
	 }
}

int main(void) {
	/*
		Program : Polynomial with Single Direction Linked List.
	*/
	
	struct polynomial *a1 = (struct polynomial *)malloc(sizeof(struct polynomial));
	struct polynomial *a2 = (struct polynomial *)malloc(sizeof(struct polynomial));
	struct polynomial *a3 = (struct polynomial *)malloc(sizeof(struct polynomial));
	a1->coef = 2;  a1->exp = 3; a1->next = a2;
	a2->coef = -3; a2->exp = 2; a2->next = a3;
	a3->coef = 1;  a3->exp = 0; a3->next = (struct polynomial *)NULL;
	
	struct polynomial *b1 = (struct polynomial *)malloc(sizeof(struct polynomial));
	struct polynomial *b2 = (struct polynomial *)malloc(sizeof(struct polynomial));
	struct polynomial *b3 = (struct polynomial *)malloc(sizeof(struct polynomial));
	b1->coef = 3;  b1->exp = 5; b1->next = b2;
	b2->coef = 4;  b2->exp = 2; b2->next = b3;
	b3->coef = -6; b3->exp = 1; b3->next = (struct polynomial *)NULL;
	
	struct polynomial *result = (struct polynomial *)malloc(sizeof(struct polynomial));
	result->coef = 0; result->exp = 0; result->next = (struct polynomial *)NULL;
	addition(a1, b1, result);
	
	struct polynomial *cp = result;
	while(cp != (struct polynomial *)NULL) {
		if(cp->coef > 0)  
			printf("+%dX^%d", cp->coef, cp->exp);
		else
			printf("%dX^%d", cp->coef, cp->exp);
		cp = cp->next;
	}
	
	return 0;
	}
