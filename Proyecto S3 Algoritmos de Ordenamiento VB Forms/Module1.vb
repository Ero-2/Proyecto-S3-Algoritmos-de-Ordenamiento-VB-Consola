﻿Module Module1

    Sub Main()
        Dim array() As Integer = {64, 34, 25, 12, 22, 11, 90}

        Console.WriteLine("Original array: ")
        PrintArray(array)

        ' Bubble Sort
        BubbleSort(array)
        Console.WriteLine(vbLf & "Array after Bubble Sort: ")
        PrintArray(array)

        ' Bucket Sort
        Dim maxVal As Integer = array.Max()
        BucketSort(array, maxVal)
        Console.WriteLine("Array after Bucket Sort: ")
        PrintArray(array)

        ' Binary Tree Sort
        Dim root As Node = Nothing
        For Each value In array
            root = Insert(root, value)
        Next

        BucketSort(array, maxVal)
        Console.WriteLine(vbLf & "Array after Bucket Sort: ")
        PrintArray(array)

        ' Binary Tree Sort
        BinaryTreeSort(array)
        Console.WriteLine(vbLf & "Array after Binary Tree Sort: ")
        PrintArray(array)

        ' Quick Sort
        QuickSort(array, 0, array.Length - 1)
        Console.WriteLine(vbLf & "Array after Quick Sort: ")
        PrintArray(array)

        ' Cocktail Sort
        CocktailSort(array)
        Console.WriteLine(vbLf & "Array after Cocktail Sort: ")
        PrintArray(array)

        ' Merge Direct Sort
        MergeDirectSort(array)
        Console.WriteLine(vbLf & "Array after Merge Direct Sort: ")
        PrintArray(array)

        ' Natural Merge Sort
        NaturalMergeSort(array)
        Console.WriteLine(vbLf & "Array after Natural Merge Sort: ")
        PrintArray(array)

        ' Merge Sort
        MergeSort(array)
        Console.WriteLine(vbLf & "Array after Merge Sort: ")
        PrintArray(array)

        ' Radix Sort
        RadixSort(array)
        Console.WriteLine(vbLf & "Array after Radix Sort: ")
        PrintArray(array)

        ' Shell Sort
        ShellSort(array)
        Console.WriteLine(vbLf & "Array after Shell Sort: ")
        PrintArray(array)

        ' Pigeonhole Sort
        PigeonholeSort(array)
        Console.WriteLine(vbLf & "Array after Pigeonhole Sort: ")
        PrintArray(array)

        'gnomeSort
        GnomeSort(array)
        Console.WriteLine(vbLf & "Array after Gnome Sort: ")
        PrintArray(array)

        'CombSort
        CombSort(array)
        Console.WriteLine(vbLf & "Array after Comb Sort: ")
        PrintArray(array)

        'SelectionSort
        SelectionSort(array)
        Console.WriteLine(vbLf & "Array after Selection Sort: ")
        PrintArray(array)

        'HeapSort
        HeapSort(array)
        Console.WriteLine(vbLf & "Array after HeapSort: ")
        PrintArray(array)

        'CountingSort
        CountingSort(array)
        Console.WriteLine(vbLf & "Array Counting Sort: ")
        PrintArray(array)


        Console.ReadKey()
    End Sub

    Sub PrintArray(ByRef arr() As Integer)
        For Each num In arr
            Console.Write(num & " ")
        Next
        Console.WriteLine()
    End Sub

    ' Bubble Sort
    ' Bubble Sort
    Sub BubbleSort(ByVal arr() As Integer)
        Dim n As Integer = arr.Length

        For i As Integer = 0 To n - 1
            For j As Integer = 0 To n - i - 1
                If j < n - 1 AndAlso arr(j) > arr(j + 1) Then
                    ' Si arr(j) > arr(j + 1), intercambiar elementos
                    Swap(arr, j, j + 1)
                End If
            Next
        Next
    End Sub

    ' Método para intercambiar elementos en la matriz
    Sub Swap(ByVal arr() As Integer, ByVal i As Integer, ByVal j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub

    ' Bucket Sort
    Sub BucketSort(ByRef arr() As Integer, ByVal maxVal As Integer)
        Dim bucket(maxVal) As Integer
        Dim idx As Integer = 0

        For Each value In arr
            bucket(value) += 1
        Next

        For i As Integer = 0 To bucket.Length - 1
            For j As Integer = 0 To bucket(i) - 1
                arr(idx) = i
                idx += 1
            Next
        Next
    End Sub
    'Binary Tree Sort
    Sub BinaryTreeSort(ByRef arr() As Integer)
        Dim root As Node = Nothing

        ' Construct the binary search tree
        For Each value In arr
            root = Insert(root, value)
        Next

        ' Perform in-order traversal to get sorted elements
        Dim index As Integer = 0
        InOrderTraversal(root, arr, index)
    End Sub

    Function Insert(ByVal root As Node, ByVal value As Integer) As Node
        If root Is Nothing Then
            Return New Node(value)
        End If

        If value < root.Data Then
            root.Left = Insert(root.Left, value)
        ElseIf value > root.Data Then
            root.Right = Insert(root.Right, value)
        End If

        Return root
    End Function

    Sub InOrderTraversal(ByVal root As Node, ByRef arr() As Integer, ByRef index As Integer)
        If root IsNot Nothing Then
            InOrderTraversal(root.Left, arr, index)
            arr(index) = root.Data
            index += 1
            InOrderTraversal(root.Right, arr, index)
        End If
    End Sub

    ' Quick Sort
    Sub QuickSort(ByRef arr() As Integer, ByVal low As Integer, ByVal high As Integer)
        If low < high Then
            Dim partitionIndex As Integer = Partition(arr, low, high)

            QuickSort(arr, low, partitionIndex - 1)
            QuickSort(arr, partitionIndex + 1, high)
        End If
    End Sub

    Function Partition(ByRef arr() As Integer, ByVal low As Integer, ByVal high As Integer) As Integer
        Dim pivot As Integer = arr(high)
        Dim i As Integer = low - 1

        For j As Integer = low To high - 1
            If arr(j) < pivot Then
                i += 1
                Swap(arr(i), arr(j))
            End If
        Next

        Swap(arr(i + 1), arr(high))
        Return i + 1
    End Function

    Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub

    ' Cocktail Sort
    Sub CocktailSort(ByRef arr() As Integer)
        Dim swapped As Boolean
        Do
            swapped = False

            For i As Integer = 0 To arr.Length - 2
                If arr(i) > arr(i + 1) Then
                    Swap(arr(i), arr(i + 1))
                    swapped = True
                End If
            Next

            If Not swapped Then
                Exit Do
            End If

            swapped = False

            For i As Integer = arr.Length - 2 To 0 Step -1
                If arr(i) > arr(i + 1) Then
                    Swap(arr(i), arr(i + 1))
                    swapped = True
                End If
            Next

        Loop While swapped
    End Sub

    ' Merge Direct Sort
    Sub MergeDirectSort(arr As Integer())
        Dim temp(arr.Length - 1) As Integer
        MergeDirectSort(arr, temp, 0, arr.Length - 1)
    End Sub

    Sub MergeDirectSort(arr As Integer(), temp As Integer(), left As Integer, right As Integer)
        If left < right Then
            Dim middle As Integer = (left + right) \ 2
            MergeDirectSort(arr, temp, left, middle)
            MergeDirectSort(arr, temp, middle + 1, right)
            MergeDirect(arr, temp, left, middle, right)
        End If
    End Sub

    Sub MergeDirect(arr As Integer(), temp As Integer(), left As Integer, middle As Integer, right As Integer)
        Dim i As Integer = left
        Dim j As Integer = middle + 1
        Dim k As Integer = left

        While i <= middle AndAlso j <= right
            If arr(i) <= arr(j) Then
                temp(k) = arr(i)
                k += 1
                i += 1
            Else
                temp(k) = arr(j)
                k += 1
                j += 1
            End If
        End While

        While i <= middle
            temp(k) = arr(i)
            k += 1
            i += 1
        End While

        While j <= right
            temp(k) = arr(j)
            k += 1
            j += 1
        End While

        For i = left To right
            arr(i) = temp(i)
        Next
    End Sub

    Sub NaturalMergeSort(arr As Integer())
        Dim n As Integer = arr.Length

        ' Encontrar las corridas (runs)
        Dim runs As New List(Of Integer())
        Dim start As Integer = 0
        While start < n
            Dim [end] As Integer = start + 1
            While [end] < n AndAlso arr([end] - 1) <= arr([end])
                [end] += 1
            End While

            Dim run([end] - start - 1) As Integer
            Array.Copy(arr, start, run, 0, [end] - start)
            runs.Add(run)

            start = [end]
        End While

        ' Fusionar las corridas hasta que solo quede una corrida
        While runs.Count > 1
            Dim newRuns As New List(Of Integer())
            For i As Integer = 0 To runs.Count - 1 Step 2
                If i + 1 < runs.Count Then
                    Dim mergedRun As Integer() = MergeRuns(runs(i), runs(i + 1))
                    newRuns.Add(mergedRun)
                Else
                    newRuns.Add(runs(i))
                End If
            Next
            runs = newRuns
        End While

        ' Copiar la corrida ordenada al array original
        Array.Copy(runs(0), arr, n)
    End Sub

    ' NaturalMerge
    Function MergeRuns(run1 As Integer(), run2 As Integer()) As Integer()
        Dim n1 As Integer = run1.Length
        Dim n2 As Integer = run2.Length
        Dim mergedRun(n1 + n2 - 1) As Integer

        Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
        While i < n1 AndAlso j < n2
            If run1(i) <= run2(j) Then
                mergedRun(k) = run1(i)
                k += 1
                i += 1
            Else
                mergedRun(k) = run2(j)
                k += 1
                j += 1
            End If
        End While

        While i < n1
            mergedRun(k) = run1(i)
            k += 1
            i += 1
        End While

        While j < n2
            mergedRun(k) = run2(j)
            k += 1
            j += 1
        End While

        Return mergedRun
    End Function

    ' Merge Sort
    Sub MergeSort(arr As Integer())
        MergeSort(arr, 0, arr.Length - 1)
    End Sub

    Sub MergeSort(arr As Integer(), left As Integer, right As Integer)
        If left < right Then
            Dim middle As Integer = (left + right) \ 2

            MergeSort(arr, left, middle)
            MergeSort(arr, middle + 1, right)

            Merge(arr, left, middle, right)
        End If
    End Sub

    Sub Merge(arr As Integer(), left As Integer, middle As Integer, right As Integer)
        Dim n1 As Integer = middle - left + 1
        Dim n2 As Integer = right - middle

        Dim L(n1 - 1) As Integer
        Dim R(n2 - 1) As Integer

        For ii As Integer = 0 To n1 - 1
            L(ii) = arr(left + ii)
        Next

        For jj As Integer = 0 To n2 - 1
            R(jj) = arr(middle + 1 + jj)
        Next

        Dim i As Integer = 0, j As Integer = 0
        Dim k As Integer = left
        While i < n1 AndAlso j < n2
            If L(i) <= R(j) Then
                arr(k) = L(i)
                i += 1
            Else
                arr(k) = R(j)
                j += 1
            End If
            k += 1
        End While

        While i < n1
            arr(k) = L(i)
            i += 1
            k += 1
        End While

        While j < n2
            arr(k) = R(j)
            j += 1
            k += 1
        End While
    End Sub

    ' Radix Sort
    Sub RadixSort(arr As Integer())
        Dim max As Integer = GetMax(arr)
        For exp As Integer = 1 To max \ 10
            CountSort(arr, exp)
        Next
    End Sub

    Function GetMax(arr As Integer()) As Integer
        Dim max As Integer = arr(0)
        For i As Integer = 1 To arr.Length - 1
            If arr(i) > max Then
                max = arr(i)
            End If
        Next
        Return max
    End Function

    Sub CountSort(arr As Integer(), exp As Integer)
        Dim n As Integer = arr.Length
        Dim output(n - 1) As Integer
        Dim count(9) As Integer

        For i As Integer = 0 To n - 1
            count((arr(i) \ exp) Mod 10) += 1
        Next

        For i As Integer = 1 To 9
            count(i) += count(i - 1)
        Next

        For i As Integer = n - 1 To 0 Step -1
            output(count((arr(i) \ exp) Mod 10) - 1) = arr(i)
            count((arr(i) \ exp) Mod 10) -= 1
        Next

        For i As Integer = 0 To n - 1
            arr(i) = output(i)
        Next
    End Sub

    ' Shell Sort
    Sub ShellSort(arr As Integer())
        Dim n As Integer = arr.Length
        For gap As Integer = n \ 2 To 0 Step gap \ 2
            For i As Integer = gap To n - 1
                Dim temp As Integer = arr(i)
                Dim j As Integer
                For j = i To gap And arr(j - gap) > temp Step -gap
                    arr(j) = arr(j - gap)
                Next
                arr(j) = temp
            Next
        Next
    End Sub

    ' Pigeonhole Sort
    Sub PigeonholeSort(arr As Integer())
        Dim n As Integer = arr.Length
        Dim min As Integer = arr(0)
        Dim max As Integer = arr(0)

        For i As Integer = 1 To n - 1
            If arr(i) < min Then
                min = arr(i)
            End If
            If arr(i) > max Then
                max = arr(i)
            End If
        Next

        Dim range As Integer = max - min + 1
        Dim holes(range - 1) As List(Of Integer)

        For i As Integer = 0 To range - 1
            holes(i) = New List(Of Integer)()
        Next

        For i As Integer = 0 To n - 1
            holes(arr(i) - min).Add(arr(i))
        Next

        Dim index As Integer = 0

        For i As Integer = 0 To range - 1
            For Each value As Integer In holes(i)
                arr(index) = value
                index += 1
            Next
        Next
    End Sub

    Sub GnomeSort(ByRef arr() As Integer)
        Dim n As Integer = arr.Length
        Dim index As Integer = 0

        While index < n
            If index = 0 Then
                index += 1
            End If

            If arr(index) >= arr(index - 1) Then
                index += 1
            Else
                Swap(arr, index, index - 1)
                index -= 1
            End If
        End While
    End Sub

    Sub Swapp(ByRef arr() As Integer, ByVal a As Integer, ByVal b As Integer)
        Dim temp As Integer = arr(a)
        arr(a) = arr(b)
        arr(b) = temp
    End Sub

    Sub CombSort(ByRef arr() As Integer)
        Dim n As Integer = arr.Length
        Dim gap As Integer = n
        Dim swapped As Boolean = True

        While gap > 1 OrElse swapped
            gap = Math.Max(1, CInt(gap / 1.3))
            swapped = False

            For i As Integer = 0 To n - gap - 1
                If arr(i) > arr(i + gap) Then
                    Swap(arr, i, i + gap)
                    swapped = True
                End If
            Next
        End While
    End Sub

    Sub SelectionSort(ByRef arr() As Integer)
        Dim n As Integer = arr.Length

        For i As Integer = 0 To n - 2
            Dim minIndex As Integer = i

            For j As Integer = i + 1 To n - 1
                If arr(j) < arr(minIndex) Then
                    minIndex = j
                End If
            Next

            Swap(arr, i, minIndex)
        Next
    End Sub

    Sub HeapSort(ByRef arr() As Integer)
        Dim n As Integer = arr.Length

        ' Construir el heap (montículo)
        For i As Integer = CInt(n / 2) - 1 To 0 Step -1
            Heapify(arr, n, i)
        Next

        ' Extraer elementos del heap uno por uno
        For i As Integer = n - 1 To 1 Step -1
            ' Mover la raíz actual al final del array
            Swap(arr, 0, i)

            ' Llamar al procedimiento Heapify en la raíz reducida
            Heapify(arr, i, 0)
        Next
    End Sub

    Sub Heapify(ByRef arr() As Integer, ByVal n As Integer, ByVal i As Integer)
        Dim largest As Integer = i
        Dim leftChild As Integer = 2 * i + 1
        Dim rightChild As Integer = 2 * i + 2

        ' Si el hijo izquierdo es más grande que la raíz
        If leftChild < n AndAlso arr(leftChild) > arr(largest) Then
            largest = leftChild
        End If

        ' Si el hijo derecho es más grande que el más grande hasta ahora
        If rightChild < n AndAlso arr(rightChild) > arr(largest) Then
            largest = rightChild
        End If

        ' Si el más grande no es la raíz
        If largest <> i Then
            Swap(arr, i, largest)

            ' Llamar recursivamente al procedimiento Heapify en el subárbol afectado
            Heapify(arr, n, largest)
        End If
    End Sub

    Sub CountingSort(ByRef arr() As Integer)
        Dim n As Integer = arr.Length

        ' Encontrar el valor máximo en el array
        Dim max As Integer = arr(0)
        For i As Integer = 1 To n - 1
            If arr(i) > max Then
                max = arr(i)
            End If
        Next

        ' Crear un array de conteo y inicializar todas las posiciones con 0
        Dim count(max) As Integer
        For i As Integer = 0 To max
            count(i) = 0
        Next

        ' Incrementar el conteo de cada elemento en el array original
        For i As Integer = 0 To n - 1
            count(arr(i)) += 1
        Next

        ' Actualizar el array original con los elementos ordenados
        Dim index As Integer = 0
        For i As Integer = 0 To max
            While count(i) > 0
                arr(index) = i
                index += 1
                count(i) -= 1
            End While
        Next
    End Sub


End Module
