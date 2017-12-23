#include <stdio.h>
#include <stdlib.h>
#include <memory.h>

void printArray(int *array, int arrayLength) {
	int i = 0;
	for(i = 0; i < arrayLength; i++) 
		printf("(%d)\t", i);
	printf("\n");
	for(i = 0; i < arrayLength; i++) 
		printf("%d\t", array[i]);
	printf("\n");
	return;
}

int *addNode(int *array, int *arrayLength, int value) {
	int *arrayPtr = (int *)realloc(array, (++*arrayLength) * sizeof(int));
	if(arrayPtr != array)
		free(array);
	arrayPtr[*arrayLength - 1] = value;
	return arrayPtr;
}

int *insNode(int *array, int *arrayLength, int position, int value) {
	if(position > *arrayLength || position <= 0) {
		printf("> Position error.\n");
		return array;
	} else {
        int *arrayPtr = (int *)malloc((++*arrayLength) * sizeof(int));
        memcpy(arrayPtr, array, position * sizeof(int));
        arrayPtr[position] = value;
        memcpy(&arrayPtr[position + 1], &array[position], (*arrayLength - 1 - position) * sizeof(int));
        return arrayPtr;
	}
}

int *delNode(int *array, int *arrayLength) {
    array[1] = 0;
    int *arrayPtr = (int *)malloc((--*arrayLength) * sizeof(int));
    memcpy(arrayPtr, &array[1], *arrayLength * sizeof(int));
    free(array);
    return arrayPtr;
}

void swap(int *nodeA, int *nodeB) {
	int temp = *nodeA;
	*nodeA = *nodeB;
	*nodeB = temp;
	return;
}

void maxHeapify(int *array, int root, int arrayLength) { 
	int left = 2 * root, right = 2 * root + 1, largest = root;
	largest = left <= arrayLength && array[left] > array[root] ? left : largest;
	largest = right <= arrayLength && array[right] > array[largest] ? right : largest;
	
	if(largest != root) {
		swap(&array[largest], &array[root]);
		maxHeapify(array, largest, arrayLength);
	}
	return;
} 

int main(void) {
	/*
		Program : Max-Heap 
		Function:
			Allow user input/insert node with a value,
			able to remove any node whatever user want to,
			and automatically adjust whole array into Max-Heap status.
	*/
	
	int *array = (int *)calloc(1, sizeof(int));
	int arrayLength = 1, action = 0, value = 0;
	do {
		printf("(0) Add\n(1) Insert\n(2) Delete\n(3) Print\n(4) Max-Heapify\n(-1) Exit\n>");
		scanf("%d", &action);
		switch(action) {
			case 0: {
				printf(">>> Input add value: ");
				scanf("%d", &value);
				array = addNode(array, &arrayLength, value);
				printArray(array, arrayLength);
				break;
			}
			case 1: {
				int position = 0;
				printf(">>> Input insert position: ");
				scanf("%d", &position);
				printf(">>> Input insert value: ");
				scanf("%d", &value);
				array = insNode(array, &arrayLength, position, value);
				printArray(array, arrayLength);
				break;
			}
			case 2: {
				array = delNode(array, &arrayLength);
				printArray(array, arrayLength);
				break;
			}
			case 3: {
				printArray(array, arrayLength);
				break;
			}
			case 4: {
				printf(">>> Max-Heapify.\n");
				int i = arrayLength / 2;
				for(i;i >= 1; i--)
					maxHeapify(array, i, arrayLength - 1);
				printArray(array, arrayLength);
				break;
			}
			case -1:{
				action = -1;
				break;
			}
		}
	} while(action != -1);
	
	return 0;
}
