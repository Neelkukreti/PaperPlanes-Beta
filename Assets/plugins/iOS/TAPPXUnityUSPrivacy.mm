#import "TAPPXUnityUSPrivacy.h"

extern UIViewController* UnityGetGLViewController();
extern UIView* UnityGetGLView();

@implementation TAPPXUnityUSPrivacy

- (id)init {
    self = [super init];
    if (self != nil) {
        
    }
    return self;
}

+ (void)setUSPrivacy:(NSString*)consent{
    [TappxFramework setUsPrivacy:consent];
}

- (void)dealloc {}

@end
extern "C" {
    void setUSPrivacy_(char *consent);
}

void setUSPrivacy_(char *consent){
    [TAPPXUnityUSPrivacy setUSPrivacy:[NSString stringWithCString:consent encoding:NSASCIIStringEncoding]];
}
