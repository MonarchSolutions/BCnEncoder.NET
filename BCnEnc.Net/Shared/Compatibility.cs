using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Toolkit.HighPerformance;

namespace BCnEncoder.Shared
{
	internal static class Compatibility
	{
		public static float Clamp(float value, float min, float max)
		{
			return value < min ? min : value > max ? max : value;
		}

		public static void Fill<T>(T[] array, T value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<T> CreateSpan<T>(ref T reference, int length)
		{
			unsafe
			{
				return new Span<T>(Unsafe.AsPointer(ref reference), length);
			}
		}

#if NETSTANDARD2_0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory2D<T> AsMemory2D<T>(this Memory<T> memory, int height, int width)
		{
			return new Memory2D<T>(memory.ToArray(), height, width);
		}

		public static Span<T> GetRowSpan<T>(this Span2D<T> span2D, int i)
		{
			return span2D.GetRow(i).ToArray();
		}

		public static Span<T> GetRowSpan<T>(this ReadOnlySpan2D<T> span2D, int i)
		{
			return span2D.GetRow(i).ToArray();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan2D<T> AsSpan2D<T>(this ReadOnlySpan<T> span, int height, int width)
		{
			return new ReadOnlySpan2D<T>(span.ToArray(), height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span2D<T> AsSpan2D<T>(this Span<T> span, int height, int width)
		{
			return new Span2D<T>(span.ToArray(), height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<T> AsSpan<T>(this T[,] array)
		{
			if (array is null)
			{
				return default;
			}

			if (array.IsCovariant())
			{
				throw new ArrayTypeMismatchException();
			}

			ref T r0 = ref array.DangerousGetReference();
			int length = array.Length;

			return CreateSpan(ref r0, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory2D<T> AsMemory2D<T>(this ReadOnlyMemory<T> memory, int height, int width)
		{
			return new ReadOnlyMemory2D<T>(memory.ToArray(), height, width);
		}

		public static void Write(this BinaryWriter bw, ReadOnlySpan<byte> buffer)
		{
			bw.BaseStream.Write(buffer);
		}

		public static int Read(this BinaryReader br, Span<byte> buffer)
		{
			return br.BaseStream.Read(buffer);
		}
#endif
	}
}
