namespace BCnEncoder.Shared
{
    public enum CompressionFormat
    {
        /// <summary>
        /// Raw unsigned byte 8-bit Luminance data
        /// </summary>
        R,
        /// <summary>
        /// Raw unsigned byte 16-bit RG data
        /// </summary>
        Rg,
        /// <summary>
        /// Raw unsigned byte 24-bit RGB data
        /// </summary>
        Rgb,
        /// <summary>
        /// Raw unsigned byte 32-bit RGBA data
        /// </summary>
        Rgba,
        /// <summary>
        /// BC1 / DXT1 with no alpha. Very widely supported and good compression ratio.
        /// </summary>
        Bc1,
        /// <summary>
        /// BC1 / DXT1 with 1-bit of alpha.
        /// </summary>
        Bc1WithAlpha,
        /// <summary>
        /// BC2 / DXT3 encoding with alpha. Good for sharp alpha transitions.
        /// </summary>
        Bc2,
        /// <summary>
        /// BC3 / DXT5 encoding with alpha. Good for smooth alpha transitions.
        /// </summary>
        Bc3,
        /// <summary>
        /// BC4 single-channel encoding. Only luminance is encoded.
        /// </summary>
        Bc4,
        /// <summary>
        /// BC5 dual-channel encoding. Only red and green channels are encoded.
        /// </summary>
        Bc5,
        /// <summary>
        /// BC6H / BPTC float encoding. Can compress HDR textures without alpha. Currently not supported.
        /// </summary>
        Bc6,
        /// <summary>
        /// BC7 / BPTC unorm encoding. Very high Quality rgba or rgb encoding. Also very slow.
        /// </summary>
        Bc7,
		/// <summary>
		/// ATC / Adreno Texture Compression encoding. Derivative of BC1.
		/// </summary>
		Atc,
		/// <summary>
		/// ATC / Adreno Texture Compression encoding. Derivative of BC1. Good for sharp alpha transitions.
		/// </summary>
		AtcExplicitAlpha,
		/// <summary>
		/// ATC / Adreno Texture Compression encoding. Derivative of BC1. Good for smooth alpha transitions.
		/// </summary>
		AtcInterpolatedAlpha
	}

    public static class CompressionFormatExtensions
    {
        public static bool IsCompressedFormat(this CompressionFormat format)
        {
            switch (format)
            {
                case CompressionFormat.R:
                case CompressionFormat.Rg:
                case CompressionFormat.Rgb:
                case CompressionFormat.Rgba:
                    return false;

                default:
                    return true;
            }
        }
    }
}
