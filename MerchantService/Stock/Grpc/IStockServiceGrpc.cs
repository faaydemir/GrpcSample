using System.ServiceModel;
using System.Runtime.Serialization;
using ProtoBuf.Grpc;

[ServiceContract]
public interface IStockServiceGrpc
{
    [OperationContract]
    Task<GetStockResponse> GetStock(GetStockRequest request, CallContext context = default);

    [OperationContract]
    Task<GetStockResponse> AddStock(AddStockRequestGrpc request, CallContext context = default);
}

[DataContract]
public class GetStockRequest
{
    [DataMember(Order = 1)]
    public int ProductId { get; set; }
}

[DataContract]
public class GetStockResponse
{
    [DataMember(Order = 1)]
    public int ProductId { get; set; }

    [DataMember(Order = 2)]
    public int Stock { get; set; }
}


[DataContract]
public class AddStockRequestGrpc
{
    [DataMember(Order = 1)]
    public int ProductId { get; set; }

    [DataMember(Order = 2)]
    public int Count { get; set; }
}

