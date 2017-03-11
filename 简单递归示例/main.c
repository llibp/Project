#include <stdio.h>
#include <stdlib.h>
//ʾ��1
//��Ѳ��������� ��i��Ԫ�ص�ֵ��1 1 2 3 5 8 ����
int Fib_1(int i)
{
    if(i<2)
        return i==0?0:1;
    return Fib_1(i-1)+Fib_1(i-2);
}
//ʾ��2
//����n�Ľ׳�
int JC(int n)
{
    if(n>1)
        return n*JC(n-1);
    else
        return 1;
}

//ʾ��3
//�������һ���ַ���,�ַ���#������־
void ResverString()
{
    char a;
    scanf("%c",&a);
    if(a!='#') ResverString();
    if(a!='#') printf("%c",a);
}


//ʾ��4
//�ݹ��۰���ҷ�
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
            printf("�ݹ飺%d is located at %d\r\n",value,mid+1);
            return;
        }
        mid = (low + high)/2;
    }
    else
    {
        printf("û���ҵ�\r\n");
    }
}

//ʾ��5
//�����۰���ҷ�
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
            printf("������%d is located at %d\r\n",value,mid+1);
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
    printf("û���ҵ�\r\n");
}

//ʾ��6
//��ŵ��
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
    printf("��������Ҫ����ķѲ��������еڣ�����:\r\n");
    scanf("%d",&n);
    result = Fib_1(n);
    printf("�Ѳ��������� : %d\n\r\n",result);


    //2
    printf("��������Ҫ����Ľ׳���:\r\n");
    scanf("%d",&n);
    result = JC(n);
    printf("�׳� : %d\n\n",result);



    //3
    //�������һ���ַ���,�ַ���#������־
    printf("������һ���ַ����������������\r\n");
    ResverString();


    //4
    //�۰�
    int a[] ={1,2,3,4,5,6,7,8,9};
    printf("������Ҫ���ҵ���\r\n");
    scanf("%d",&n);
    HalfFind2(a,9,n);//����
    HalfFind(a,0,9,n);//�ݹ�


    //��ŵ��
    printf("�����뺺ŵ���Ĳ�����\r\n");
    scanf("%d",&n);
    HanNuoTa(n,'A','B','C');
    return 0;
}
