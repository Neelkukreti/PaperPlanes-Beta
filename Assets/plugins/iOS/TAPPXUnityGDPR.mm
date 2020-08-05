#import "TAPPXUnityGDPR.h"

extern UIViewController* UnityGetGLViewController();
extern UIView* UnityGetGLView();

@implementation TAPPXUnityGDPR

- (id)init {
    self = [super init];
    if (self != nil) {
        
    }
    return self;
}

+ (void)acceptPersonalInfoContent:(BOOL)accept{
    [TappxFramework acceptPersonalInfoContent:accept];
}

+ (void)setGDPRConsent:(NSString*)consent{
    [TappxFramework setGDPRConsent:consent];
}

- (void)dealloc {}

@end
extern "C" {
    void acceptPersonalInfoContent_( bool accept );
    void setGDPRConsent_(char *consent);
}

void acceptPersonalInfoContent_(bool accept){
    [TAPPXUnityGDPR acceptPersonalInfoContent:accept];
}

void setGDPRConsent_(char *consent){
    [TAPPXUnityGDPR setGDPRConsent:[NSString stringWithCString:consent encoding:NSASCIIStringEncoding]];
}
