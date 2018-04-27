#include <iostream>
#include <time.h>
using namespace std;

long double noInline(long double n) {
    return n * n;
}

int main(void) {

    int N = 0, exeN = 0;
    cin >> N >> exeN;
    int startTime = 0, endTime = 0, exeTime = 0;

    cout << "N " << N << ", exeN " << exeN << endl;
    for(int n = 0; n < N; n++) {
        startTime = time(0);
        cout << "\t| StartTime " << startTime << " | ";

        for(int i = 0; i < exeN; ++i) {
            long double result = noInline(i);
            cout << result << " ";
            //cout << "FACT(" << i << ")=" << result << endl;
        }

        endTime = time(0);
        cout << endl << "EndTime " << endTime << " | ";
        exeTime = endTime - startTime;
        cout << "ExeTime " << exeTime << endl;
    }
    return 0;
}

