using FileHelpers;
using System;
using System.Collections.Generic;
using CommonLib.Logic;
using CommonLib.Extensions;

namespace FormatBBV3.Logic.Data.PurchaseOrder
{
	public class Files : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public int CreateBatch(string filename, string vendor)
		{
			int batchnumber = 0;
			try
			{
				batchnumber = CommonLib.Logic.Globals.CreateBatch(filename, vendor, 2);
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return batchnumber;
		}

		public bool WriteFileAddingSequence(string filename, Models.Files.PurchaseOrder.DataSequence.V3 data, bool checkseq)
		{
			List<object> writelist = new List<object>();
			bool success = false;
			short seqnum = 1;
			try
			{
				//build list

				data.FileHeaderRecord.SequenceNumber = seqnum++;
				writelist.Add(data.FileHeaderRecord);
				if (data.PurchaseOrders != null && data.PurchaseOrders.Count > 0)
				{
					foreach (Models.Files.PurchaseOrder.DataSequence.PurchaseOrder item in data.PurchaseOrders)
					{
						item.ClientHeaderRecord.SequenceNumber = seqnum++;
						writelist.Add(item.ClientHeaderRecord);
						if (Common.IsValid(item.FixedHandlingInstructionsRecord, checkseq))
						{
							item.FixedHandlingInstructionsRecord.SequenceNumber = seqnum++;
							writelist.Add(item.FixedHandlingInstructionsRecord);
						}
						if (Common.IsValid(item.PurchaseOrderOptionsRecord, checkseq))
						{
							item.PurchaseOrderOptionsRecord.SequenceNumber = seqnum++;
							writelist.Add(item.PurchaseOrderOptionsRecord);
						}
						if (item.PurchaseOrderDetails != null && item.PurchaseOrderDetails.Count > 0)
						{
							foreach (Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail detail in item.PurchaseOrderDetails)
							{
								if (Common.IsValid(detail.LineItemDetail, checkseq))
								{
									detail.LineItemDetail.SequenceNumber = seqnum++;
									writelist.Add(detail.LineItemDetail);
								}
								if (Common.IsValid(detail.AdditionalLineItemDetail, checkseq))
								{
									detail.AdditionalLineItemDetail.SequenceNumber = seqnum++;
									writelist.Add(detail.AdditionalLineItemDetail);
								}
								if (detail.Imprint != null && detail.Imprint.Count > 0)
								{
									foreach (Models.Files.PurchaseOrder.R45_Imprint imprint in detail.Imprint)
									{
										if (Common.IsValid(imprint, checkseq) && !string.IsNullOrEmpty(imprint.PONumber))
										{
											imprint.SequenceNumber = seqnum++;
											writelist.Add(imprint);
										}
									}
								}
								if (Common.IsValid(detail.StickerBarcodeDataRecord, checkseq) && !string.IsNullOrEmpty(detail.StickerBarcodeDataRecord.PONumber))
								{
									detail.StickerBarcodeDataRecord.SequenceNumber = seqnum++;
									writelist.Add(detail.StickerBarcodeDataRecord);
								}
								if (detail.StickerTextLines != null && detail.StickerTextLines.Count > 0)
								{
									foreach (Models.Files.PurchaseOrder.R46_StickerTextLines text in detail.StickerTextLines)
									{
										if (Common.IsValid(text, checkseq) && !string.IsNullOrEmpty(text.PONumber))
										{
											text.SequenceNumber = seqnum++;
											writelist.Add(text);
										}
									}
								}

							}
						}
					}
				}
				if (Common.IsValid(data.PurchaseOrderTrailerRecord, checkseq))
				{
					data.PurchaseOrderTrailerRecord.SequenceNumber = seqnum++;
					writelist.Add(data.PurchaseOrderTrailerRecord);
				}
				if (Common.IsValid(data.FileTrailerRecord, checkseq))
				{
					data.FileTrailerRecord.SequenceNumber = seqnum++;
					writelist.Add(data.FileTrailerRecord);
				}
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseOrder.R00_ClientFileHeader),
					typeof(Models.Files.PurchaseOrder.R10_ClientHeader),
					typeof(Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions),
					typeof(Models.Files.PurchaseOrder.R21_PurchaseOrderOptions),
					typeof(Models.Files.PurchaseOrder.R40_LineItemDetail),
					typeof(Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail),
					typeof(Models.Files.PurchaseOrder.R45_Imprint),
					typeof(Models.Files.PurchaseOrder.R46_StickerBarcodeData),
					typeof(Models.Files.PurchaseOrder.R46_StickerTextLines),
					typeof(Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer),
					typeof(Models.Files.PurchaseOrder.R90_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};
				engine.WriteFile(filename, writelist.ToArray());
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return success;
		}

		public bool WriteFile(string filename, Models.Files.PurchaseOrder.DataSequence.V3 data, bool checkseq)
		{
			List<object> writelist = new List<object>();
			bool success = false;
			try
			{
				//build list
				writelist.Add(data.FileHeaderRecord);
				if (data.PurchaseOrders != null && data.PurchaseOrders.Count > 0)
				{
					foreach (Models.Files.PurchaseOrder.DataSequence.PurchaseOrder item in data.PurchaseOrders)
					{
						writelist.Add(item.ClientHeaderRecord);
						if (Common.IsValid(item.FixedHandlingInstructionsRecord, checkseq)) { writelist.Add(item.FixedHandlingInstructionsRecord); }
						if (Common.IsValid(item.PurchaseOrderOptionsRecord, checkseq)) { writelist.Add(item.PurchaseOrderOptionsRecord); }
						if (item.PurchaseOrderDetails != null && item.PurchaseOrderDetails.Count > 0)
						{
							foreach(Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail detail in item.PurchaseOrderDetails)
							{
								if (Common.IsValid(detail.LineItemDetail,checkseq)) { writelist.Add(detail.LineItemDetail); }
								if (Common.IsValid(detail.AdditionalLineItemDetail, checkseq)) { writelist.Add(detail.AdditionalLineItemDetail); }
								if (detail.Imprint != null && detail.Imprint.Count > 0)
								{
									foreach(Models.Files.PurchaseOrder.R45_Imprint imprint in detail.Imprint)
									{
										if (Common.IsValid(imprint, checkseq)) { writelist.Add(imprint); }
									}
								}
								if (Common.IsValid(detail.StickerBarcodeDataRecord, checkseq)) { writelist.Add(detail.StickerBarcodeDataRecord); }
								if (detail.StickerTextLines != null && detail.StickerTextLines.Count > 0)
								{
									foreach (Models.Files.PurchaseOrder.R46_StickerTextLines text in detail.StickerTextLines)
									{
										if (Common.IsValid(text, checkseq)) { writelist.Add(text); }
									}
								}
								
							}
						}
					}
				}
				if (Common.IsValid(data.PurchaseOrderTrailerRecord, checkseq)) { writelist.Add(data.PurchaseOrderTrailerRecord); }
				if (Common.IsValid(data.FileTrailerRecord, checkseq)) { writelist.Add(data.FileTrailerRecord); }
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseOrder.R00_ClientFileHeader),
					typeof(Models.Files.PurchaseOrder.R10_ClientHeader),
					typeof(Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions),
					typeof(Models.Files.PurchaseOrder.R21_PurchaseOrderOptions),
					typeof(Models.Files.PurchaseOrder.R40_LineItemDetail),
					typeof(Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail),
					typeof(Models.Files.PurchaseOrder.R45_Imprint),
					typeof(Models.Files.PurchaseOrder.R46_StickerBarcodeData),
					typeof(Models.Files.PurchaseOrder.R46_StickerTextLines),
					typeof(Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer),
					typeof(Models.Files.PurchaseOrder.R90_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};
				engine.WriteFile(filename, writelist.ToArray());
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return success;
		}

		public Models.Files.PurchaseOrder.DataSequence.V3 ReadFile(string filename, int batchnumber)
		{
			List<Models.Files.PurchaseOrder.R00_ClientFileHeader> r00 = null;
			List<Models.Files.PurchaseOrder.R10_ClientHeader> r10 = null;
			List<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions> r20 = null;
			List<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions> r21 = null;
			List<Models.Files.PurchaseOrder.R40_LineItemDetail> r40 = null;
			List<Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail> r41 = null;
			List<Models.Files.PurchaseOrder.R45_Imprint> r45 = null;
			List<Models.Files.PurchaseOrder.R46_StickerBarcodeData> r46barcode = null;
			List<Models.Files.PurchaseOrder.R46_StickerTextLines> r46text = null;
			List<Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer> r50 = null;
			List<Models.Files.PurchaseOrder.R90_FileTrailer> r90 = null;
			//
			Models.Files.PurchaseOrder.DataSequence.V3 file = null;
			Models.Files.PurchaseOrder.DataSequence.PurchaseOrder order = null;
			Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail orderdetail = null;
			//
			string typename = string.Empty;
			int orderdetailCount = 0;
			int orderCount = 0;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseOrder.R00_ClientFileHeader),
					typeof(Models.Files.PurchaseOrder.R10_ClientHeader),
					typeof(Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions),
					typeof(Models.Files.PurchaseOrder.R21_PurchaseOrderOptions),
					typeof(Models.Files.PurchaseOrder.R40_LineItemDetail),
					typeof(Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail),
					typeof(Models.Files.PurchaseOrder.R45_Imprint),
					typeof(Models.Files.PurchaseOrder.R46_StickerBarcodeData),
					typeof(Models.Files.PurchaseOrder.R46_StickerTextLines),
					typeof(Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer),
					typeof(Models.Files.PurchaseOrder.R90_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.PurchaseOrder.Selectors.V3.Custom)
				};

				var res = engine.ReadFile(filename);
				if (res != null && res.Length > 0)
				{
					file = new Models.Files.PurchaseOrder.DataSequence.V3();
					foreach (var rec in res)
					{
						typename = rec.GetType().Name.ToUpper();
						switch (typename)
						{
							case "R00_CLIENTFILEHEADER":
								Common.Initialize(ref r00);
								r00.Add((Models.Files.PurchaseOrder.R00_ClientFileHeader)rec);
								file.FileHeaderRecord = r00.LastItem();
								break;

							case "R10_CLIENTHEADER":
								Common.Initialize(ref r10);
								r10.Add((Models.Files.PurchaseOrder.R10_ClientHeader)rec);
								if (orderCount > 0)
								{
									if (file.PurchaseOrders == null)  { file.PurchaseOrders = new List<Models.Files.PurchaseOrder.DataSequence.PurchaseOrder>(); }
									if (order != null) { file.PurchaseOrders.Add(order); }
								}
								orderCount++;
								order = new Models.Files.PurchaseOrder.DataSequence.PurchaseOrder
								{
									ClientHeaderRecord = r10.LastItem()
								};
								break;

							case "R20_FIXEDSPECIALHANDLINGINSTRUCTIONS":
								Common.Initialize(ref r20);
								r20.Add((Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions)rec);
								order.FixedHandlingInstructionsRecord = r20.LastItem();
								break;

							case "R21_PURCHASEORDEROPTIONS":
								Common.Initialize(ref r21);
								r21.Add((Models.Files.PurchaseOrder.R21_PurchaseOrderOptions)rec);
								order.PurchaseOrderOptionsRecord = r21.LastItem();
								break;

							case "R40_LINEITEMDETAIL":
								Common.Initialize(ref r40);
								r40.Add((Models.Files.PurchaseOrder.R40_LineItemDetail)rec);
								if (orderdetailCount > 0)
								{
									if (order.PurchaseOrderDetails == null) { order.PurchaseOrderDetails = new List<Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail>(); }
									if (orderdetail != null) { order.PurchaseOrderDetails.Add(orderdetail); }
								}
								orderdetailCount++;
								orderdetail = new Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail
								{
									LineItemDetail = r40.LastItem()
								};
								break;

							case "R41_ADDITIONALLINEITEMDETAIL":
								Common.Initialize(ref r41);
								r41.Add((Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail)rec);
								orderdetail.AdditionalLineItemDetail = r41.LastItem();
								break;

							case "R45_IMPRINT":
								Common.Initialize(ref r45);
								r45.Add((Models.Files.PurchaseOrder.R45_Imprint)rec);
								if (orderdetail.Imprint == null)
								{
									orderdetail.Imprint = new List<Models.Files.PurchaseOrder.R45_Imprint>();
								}
								if (file.Maxes.ContainsKey(typename) && orderdetail.Imprint.Count < file.Maxes[typename])
								{
									orderdetail.Imprint.Add(r45.LastItem());
								}
								break;

							case "R46_STICKERBARCODEDATA":
								Common.Initialize(ref r46barcode);
								r46barcode.Add((Models.Files.PurchaseOrder.R46_StickerBarcodeData)rec);
								orderdetail.StickerBarcodeDataRecord =r46barcode.LastItem();
								break;

							case "R46_STICKERTEXTLINES":
								Common.Initialize(ref r46text);
								r46text.Add((Models.Files.PurchaseOrder.R46_StickerTextLines)rec);
								if (orderdetail.StickerTextLines == null) { orderdetail.StickerTextLines = new List<Models.Files.PurchaseOrder.R46_StickerTextLines>(); }
								if (file.Maxes.ContainsKey(typename) && orderdetail.StickerTextLines.Count < file.Maxes[typename])
								{
									orderdetail.StickerTextLines.Add(r46text.LastItem());
								}
								break;

							case "R50_PURCHASEORDERTRAILER":
								Common.Initialize(ref r50);
								r50.Add((Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer)rec);
								file.PurchaseOrderTrailerRecord = r50.LastItem();
								if (orderdetail != null)
								{
									if (order.PurchaseOrderDetails == null) { order.PurchaseOrderDetails = new List<Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail>(); }
									order.PurchaseOrderDetails.Add(orderdetail);
								}
								file.PurchaseOrders.Add(order);
								break;

							case "R90_FILETRAILER":
								Common.Initialize(ref r90);
								r90.Add((Models.Files.PurchaseOrder.R90_FileTrailer)rec);
								file.FileTrailerRecord = r90.LastItem();
								break;
						}
					}
					using (SQL sql = new SQL())
					{
						// add batch info
						sql.SaveR00_ClientFileHeader(r00, batchnumber);
						sql.SaveR10_ClientHeader(r10, batchnumber);
						sql.SaveR20_FixedSpecialHandlingInstructions(r20, batchnumber);
						sql.SaveR21_PurchaseOrderOptions(r21, batchnumber);
						sql.SaveR40_LineItemDetail(r40, batchnumber);
						sql.SaveR41_AdditionalLineItemDetail(r41, batchnumber);
						sql.SaveR45_Imprint(r45, batchnumber);
						sql.SaveR46_StickerBarcode(r46barcode, batchnumber);
						sql.SaveR46_StickerTextLines(r46text, batchnumber);
						sql.SaveR50_PurchaseOrderTrailer(r50, batchnumber);
						sql.SaveR90_FileTrailer(r90, batchnumber);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return file;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~Files() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}