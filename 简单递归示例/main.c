#include <stdio.h>
#include <stdlib.h>
//示例1
//求费布拉奇数列 中i个元素的值：1 1 2 3 5 8 数列
int Fib_1(int i)
{
    if(i<2)
        return i==0?0:1;
    return Fib_1(i-1)+Fib_1(i-2);
}
//示例2
//计算n的阶乘
int JC(int n)
{
    if(n>1)
        return n*JC(n-1);
    else
        return 1;
}

//示例3
//逆序输出一段字符串,字符串#结束标志
void ResverString()
{
    char a;
    scanf("%c",&a);
    if(a!='#') ResverString();
    if(a!='#') printf("%c",a);
}


//示例4
//递归折半查找法
void HalfFind(int *a ,int l ,int h,int value)
{
    int *p = a;
    int low = l;
    int high = h;
    int mid = (low+high)/2;

    if(low < high)
    {
        if(*(p+mid) < value)
        {
            low = mid + 1;
            HalfFind(p ,low ,high,value);
        }
        else if(*(p+mid) > value)
        {
            high = mid -1;
            HalfFind(p ,low ,high,value);
        }
        else
        {
            printf("递归：%d is located at %d\r\n",value,mid+1);
            return;
        }
        mid = (low + high)/2;
    }
    else
    {
        printf("没有找到\r\n");
    }
}

//示例5
//迭代折半查找法
void HalfFind2(int *a ,int n ,int value)
{
    int *p = a;
    int low = 0;
    int high = n;
    int mid = (low+high)/2;
    while(low < high)
    {

        if(*(p+mid) == value)
        {
            printf("迭代：%d is located at %d\r\n",value,mid+1);
            return;
        }
        else if(*(p+mid) < value)
        {
            low = mid + 1;
        }
        else
        {
            high = mid -1;
        }

        mid = (low + high)/2;
    }
    printf("没有找到\r\n");
}

//示例6
//汉诺塔
void HanNuoTa(int num, char A ,char B ,char C)
{
    if(num == 1)
    {
        printf("%c --> %c\r\n",A,C);
    }
    else
    {
        HanNuoTa(num-1,A,C,B);
        printf("%c --> %c\r\n",A,C);
        HanNuoTa(num-1,B,A,C);
    }
}








int main()
{
    int n = 0;
    int result = 0;

    //1
    printf("请输入需要计算的费布拉奇数列第？个数:\r\n");
    scanf("%d",&n);
    result = Fib_1(n);
    printf("费布拉奇数列 : %d\n\r\n",result);


    //2
    printf("请输入需要计算的阶乘数:\r\n");
    scanf("%d",&n);
    result = JC(n);
    printf("阶乘 : %d\n\n",result);



    //3
    //逆序输出一段字符串,字符串#结束标志
    printf("请输入一串字符串，用于逆序操作\r\n");
    ResverString();


    //4
    //折半
    int a[] ={1,2,3,4,5,6,7,8,9};
    printf("请输入要查找的数\r\n");
    scanf("%d",&n);
    HalfFind2(a,9,n);//迭代
    HalfFind(a,0,9,n);//递归


    //汉诺塔
    printf("请输入汉诺塔的层数：\r\n");
    scanf("%d",&n);
    HanNuoTa(n,'A','B','C');
    return 0;
}
