using System;
using System.Collections.Generic;
using System.Text;

namespace Peergrade5.Presenter.MathObjects
{
    /// <summary>
    ///     Class that represents matrix.
    /// </summary>
    public class Matrix
    {
        public double[,] matrixArr;

        public double this[int index1, int index2] {
            get {
                return matrixArr[index1, index2];
            }
            set {
                matrixArr[index1, index2] = value;
            }
        }

        /// <summary>
        ///     Get number of rows.
        /// </summary>
        /// <returns> Number of rows. </returns>
        public int RowCount() => matrixArr.GetLength(0);

        /// <summary>
        ///     Get number of columns.
        /// </summary>
        /// <returns> Number of columns. </returns>
        public int ColCount() => matrixArr.GetLength(1);

        /// <summary>
        ///     Get matrix from list double.
        /// </summary>
        /// <param name="listMatrix"> List matrix. </param>
        public Matrix(List<List<double>> listMatrix) {
            matrixArr = new double[listMatrix.Count, listMatrix[0].Count];

            for (int i = 0; i < listMatrix.Count; i++) {
                for (int j = 0; j < listMatrix[i].Count; j++) {
                    matrixArr[i, j] = listMatrix[i][j];
                }
            }
        }

        /// <summary>
        ///     Get matrix from array double.
        /// </summary>
        /// <param name="listMatrix"> List matrix. </param>
        public Matrix(double[,] listMatrix) {
            matrixArr = listMatrix;
        }

        /// <summary>
        ///     Initialization of matrix array.
        /// </summary>
        /// <param name="rowCount"> Number of rows. </param>
        /// <param name="colCount"> Number of columns. </param>
        public Matrix(int rowCount, int colCount) {
            matrixArr = new double[rowCount, colCount];
        }

        /// <summary>
        ///     Is the matrix a square?
        /// </summary>
        /// <returns> True if the matrix is a square. Otherwise, false. </returns>
        private bool IsSquare() => ColCount() == RowCount();

        /// <summary>
        ///     Get transposed matrix.
        /// </summary>
        /// <returns> Transposed matrix. </returns>
        public Matrix Transpose() {
            Matrix newMatrix = new Matrix(ColCount(), RowCount());

            for (int i = 0; i < RowCount(); i++) {
                for (int j = 0; j < ColCount(); j++) {
                    newMatrix.matrixArr[j, i] = matrixArr[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>
        ///     Get trace of the matrix.
        /// </summary>
        /// <returns> The trace of the matrix. </returns>
        public double Trace() {
            double resNum = 0;
            for (int i = 0; i < RowCount(); i++) {
                resNum += matrixArr[i, i];
            }

            return resNum;
        }

        /// <summary>
        ///     Get determinant of the matrix. Algorithm O(n!).
        /// </summary>
        /// <returns> The determinant of the matrix. </returns>
        public double Determinant() {
            if (ColCount() == 1)
                return matrixArr[0, 0];

            double resNum = 0;

            // Finding matrix determinant by decomposition.
            // We are decomposing by row.
            for (int i = 0; i < ColCount(); i++) {
                if (i % 2 == 0) {
                    resNum += matrixArr[0, i] * RemoveRowCol(0, i).Determinant();
                } else {
                    resNum -= matrixArr[0, i] * RemoveRowCol(0, i).Determinant();
                }
            }

            return resNum;
        }

        /// <summary>
        ///     Get new matrix from the matrix without row I and column J.
        /// </summary>
        /// <param name="removeI"> Removable row number. </param>
        /// <param name="removeJ"> Removable column number. </param>
        /// <returns> New matrix without row I and column J. </returns>
        private Matrix RemoveRowCol(int removeI, int removeJ) {
            var resListRemoved = new List<List<double>>();
            for (int i = 0; i < RowCount(); i++) {
                if (i == removeI)
                    continue;

                var listRow = new List<double>();
                for (int j = 0; j < ColCount(); j++) {
                    if (j == removeJ)
                        continue;

                    listRow.Add(matrixArr[i, j]);
                }

                resListRemoved.Add(listRow);
            }

            return new Matrix(resListRemoved);
        }

        /// <summary>
        ///     Removes column on the position <paramref name="removeCol"/>
        /// </summary>
        /// <param name="removeCol"> Number of column to be removed. </param>
        /// <returns> New matrix without column. </returns>
        private Matrix RemoveCol(int removeCol) {
            Matrix newMatrix = new Matrix(RowCount(), ColCount() - 1);
            for (int i = 0; i < RowCount(); i++) {
                // Do we need to move elements?
                bool hasChosen = false;

                for (int j = 0; j < ColCount(); j++) {
                    if (j == removeCol) {
                        hasChosen = true;
                        continue;
                    }

                    if (hasChosen)
                        newMatrix.matrixArr[i, j - 1] = matrixArr[i, j];
                    else
                        newMatrix.matrixArr[i, j] = matrixArr[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>
        ///     Replaces column on the position <paramref name="colNum"/> with column <paramref name="newCol"/>.
        /// </summary>
        /// <param name="colNum"> Number of column to be removed. </param>
        /// <param name="newCol"> Column to be set on the position. </param>
        /// <returns> New matrix with replaced column. </returns>
        private Matrix ReplaceCol(int colNum, double[] newCol) {
            Matrix newMatrix = new Matrix(RowCount(), ColCount());
            for (int i = 0; i < RowCount(); i++) {
                for (int j = 0; j < ColCount(); j++) {
                    if (j == colNum) {
                        newMatrix.matrixArr[i, colNum] = newCol[i];
                    } else {
                        newMatrix.matrixArr[i, j] = matrixArr[i, j];
                    }
                }
            }

            return newMatrix;
        }

        /// <summary>
        ///     Get column on the position <paramref name="colNum"/>.
        /// </summary>
        /// <param name="colNum"> Number of the column. </param>
        /// <returns> Column of the matrix. </returns>
        private double[] GetColumn(int colNum) {
            var resColumn = new double[RowCount()];
            for (int i = 0; i < RowCount(); i++) {
                resColumn[i] = matrixArr[i, colNum];
            }

            return resColumn;
        }

        /// <summary>
        ///     Multiplies matrix on -1.
        /// </summary>
        /// <param name="a"> Some matrix. </param>
        /// <returns> Negative matrix. </returns>
        public static Matrix operator -(Matrix a) {
            Matrix resMatrix = new Matrix(a.RowCount(), a.ColCount());
            for (int i = 0; i < a.RowCount(); i++) {
                for (int j = 0; j < a.ColCount(); j++) {
                    resMatrix.matrixArr[i, j] = -a.matrixArr[i, j];
                }
            }

            return resMatrix;
        }

        /// <summary>
        ///     Sum of two matrices.
        /// </summary>
        /// <param name="a"> First matrix. </param>
        /// <param name="b"> Second matrix. </param>
        /// <returns> Som of two matrices. </returns>
        public static Matrix operator +(Matrix a, Matrix b) {
            Matrix resMatrix = new Matrix(a.RowCount(), a.ColCount());
            for (int i = 0; i < resMatrix.RowCount(); i++) {
                for (int j = 0; j < resMatrix.ColCount(); j++) {
                    resMatrix.matrixArr[i, j] = a.matrixArr[i, j] + b.matrixArr[i, j];
                }
            }

            return resMatrix;
        }

        /// <summary>
        ///     Difference of two matrices.
        /// </summary>
        /// <param name="a"> First matrix. </param>
        /// <param name="b"> Second matrix. </param>
        /// <returns> Difference of two matrices. </returns>
        public static Matrix operator -(Matrix a, Matrix b) {
            return a + (-b);
        }

        /// <summary>
        ///     Multiplication of two matrices.
        /// </summary>
        /// <param name="a"> First matrix. </param>
        /// <param name="b"> Second matrix. </param>
        /// <returns> Multiplication of two matrices. </returns>
        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.ColCount() != b.RowCount())
                throw new ArgumentException("A col count doesn't equal b row count. ");

            var resMatrix = new Matrix(a.RowCount(), b.ColCount());
            for (int i = 0; i < a.RowCount(); i++) {
                for (int j = 0; j < b.ColCount(); j++) {
                    double sumNum = 0;
                    for (int k = 0; k < a.ColCount(); k++) {
                        sumNum += a.matrixArr[i, k] * b.matrixArr[k, j];
                    }

                    resMatrix.matrixArr[i, j] = sumNum;
                }
            }

            return resMatrix;
        }

        /// <summary>
        ///     Multiplication of matrix and some num. 
        /// </summary>
        /// <param name="a"> Some matrix. </param>
        /// <param name="num"> Some num. </param>
        /// <returns> Multiplication of matrix and some num. </returns>
        public static Matrix operator *(Matrix a, double num) {
            for (int i = 0; i < a.RowCount(); i++) {
                for (int j = 0; j < a.ColCount(); j++) {
                    a.matrixArr[i, j] *= num;
                }
            }

            return a;
        }

        public static implicit operator Point2D(Matrix a) {
            if ((a.ColCount() == 2 && a.RowCount() == 1) ||
                    (a.ColCount() == 3 && a.RowCount() == 1)) // homogeneous
                return new Point2D(a[0, 0], a[0, 1]);
            if ((a.ColCount() == 1 && a.RowCount() == 2) ||
                    (a.ColCount() == 1 && a.RowCount() == 3)) // homogeneous 
                return new Point2D(a[0, 0], a[1, 0]);

            return null;
        }
    }
}
