﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheLoanBroker.LoanBrokerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoanBrokerService.LoanBrokerSoap")]
    public interface LoanBrokerSoap {
        
        // CODEGEN: Generating message contract since element name ssn from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoanQuoteRequest", ReplyAction="*")]
        TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponse LoanQuoteRequest(TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoanQuoteRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponse> LoanQuoteRequestAsync(TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoanQuoteRequestRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoanQuoteRequest", Namespace="http://tempuri.org/", Order=0)]
        public TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequestBody Body;
        
        public LoanQuoteRequestRequest() {
        }
        
        public LoanQuoteRequestRequest(TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoanQuoteRequestRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ssn;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public double amount;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int duration;
        
        public LoanQuoteRequestRequestBody() {
        }
        
        public LoanQuoteRequestRequestBody(string ssn, double amount, int duration) {
            this.ssn = ssn;
            this.amount = amount;
            this.duration = duration;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoanQuoteRequestResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoanQuoteRequestResponse", Namespace="http://tempuri.org/", Order=0)]
        public TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponseBody Body;
        
        public LoanQuoteRequestResponse() {
        }
        
        public LoanQuoteRequestResponse(TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class LoanQuoteRequestResponseBody {
        
        public LoanQuoteRequestResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LoanBrokerSoapChannel : TheLoanBroker.LoanBrokerService.LoanBrokerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoanBrokerSoapClient : System.ServiceModel.ClientBase<TheLoanBroker.LoanBrokerService.LoanBrokerSoap>, TheLoanBroker.LoanBrokerService.LoanBrokerSoap {
        
        public LoanBrokerSoapClient() {
        }
        
        public LoanBrokerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoanBrokerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoanBrokerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoanBrokerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponse TheLoanBroker.LoanBrokerService.LoanBrokerSoap.LoanQuoteRequest(TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest request) {
            return base.Channel.LoanQuoteRequest(request);
        }
        
        public void LoanQuoteRequest(string ssn, double amount, int duration) {
            TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest inValue = new TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest();
            inValue.Body = new TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequestBody();
            inValue.Body.ssn = ssn;
            inValue.Body.amount = amount;
            inValue.Body.duration = duration;
            TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponse retVal = ((TheLoanBroker.LoanBrokerService.LoanBrokerSoap)(this)).LoanQuoteRequest(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponse> TheLoanBroker.LoanBrokerService.LoanBrokerSoap.LoanQuoteRequestAsync(TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest request) {
            return base.Channel.LoanQuoteRequestAsync(request);
        }
        
        public System.Threading.Tasks.Task<TheLoanBroker.LoanBrokerService.LoanQuoteRequestResponse> LoanQuoteRequestAsync(string ssn, double amount, int duration) {
            TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest inValue = new TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequest();
            inValue.Body = new TheLoanBroker.LoanBrokerService.LoanQuoteRequestRequestBody();
            inValue.Body.ssn = ssn;
            inValue.Body.amount = amount;
            inValue.Body.duration = duration;
            return ((TheLoanBroker.LoanBrokerService.LoanBrokerSoap)(this)).LoanQuoteRequestAsync(inValue);
        }
    }
}
